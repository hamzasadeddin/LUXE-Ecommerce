function updateCartCount() {
    fetch('/Cart/GetCount')
        .then(r => r.json())
        .then(data => {
            const badge = document.getElementById('cart-badge');
            if (badge) {
                badge.textContent = data.count;
                badge.style.display = data.count > 0 ? 'flex' : 'none';
            }
        })
        .catch(() => { });
}

function showToast(message, icon = '✦') {
    let toast = document.getElementById('luxe-toast');
    if (!toast) {
        toast = document.createElement('div');
        toast.id = 'luxe-toast';
        toast.className = 'luxe-toast';
        toast.innerHTML = `<span class="toast-icon"></span><span class="toast-msg"></span>`;
        document.body.appendChild(toast);
    }
    toast.querySelector('.toast-icon').textContent = icon;
    toast.querySelector('.toast-msg').textContent = message;
    toast.classList.add('show');
    clearTimeout(toast._timeout);
    toast._timeout = setTimeout(() => toast.classList.remove('show'), 3200);
}

function addToCart(productId, qty = 1, size = '', color = '') {
    fetch('/Cart/Add', {
        method: 'POST',
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        body: `productId=${productId}&quantity=${qty}&size=${encodeURIComponent(size)}&color=${encodeURIComponent(color)}`
    })
        .then(r => r.json())
        .then(data => {
            if (data.success) {
                updateCartCount();
                showToast('Added to your bag', '🛍');
            }
        });
}

window.addEventListener('scroll', () => {
    const navbar = document.querySelector('.luxe-navbar');
    if (navbar) navbar.classList.toggle('scrolled', window.scrollY > 40);
}, { passive: true });

function createProgressBar() {
    const bar = document.createElement('div');
    bar.id = 'page-progress';
    document.body.appendChild(bar);
}
window.addEventListener('scroll', () => {
    const bar = document.getElementById('page-progress');
    if (!bar) return;
    const scrollTop = window.scrollY;
    const docHeight = document.documentElement.scrollHeight - window.innerHeight;
    if (docHeight > 0) bar.style.width = (scrollTop / docHeight * 100) + '%';
}, { passive: true });

const revealObserver = new IntersectionObserver((entries) => {
    entries.forEach((entry, i) => {
        if (entry.isIntersecting) {
            setTimeout(() => entry.target.classList.add('visible'), i * 75);
            revealObserver.unobserve(entry.target);
        }
    });
}, { threshold: 0.1, rootMargin: '0px 0px -40px 0px' });

function initReveal() {
    document.querySelectorAll('.reveal').forEach(el => revealObserver.observe(el));
}

function animateCounter(el, target, duration = 1800) {
    let start = null;
    const suffix = el.dataset.suffix || '';
    const step = timestamp => {
        if (!start) start = timestamp;
        const progress = Math.min((timestamp - start) / duration, 1);
        const eased = 1 - Math.pow(1 - progress, 3);
        const value = Math.floor(eased * target);
        el.textContent = value.toLocaleString() + suffix;
        if (progress < 1) requestAnimationFrame(step);
    };
    requestAnimationFrame(step);
}

const counterObserver = new IntersectionObserver(entries => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            const el = entry.target;
            const target = parseInt(el.dataset.target);
            if (!isNaN(target)) animateCounter(el, target);
            counterObserver.unobserve(el);
        }
    });
}, { threshold: 0.5 });

document.addEventListener('click', function (e) {
    if (e.target.classList.contains('qty-btn')) {
        const row = e.target.closest('[data-product-id]');
        if (!row) return;
        const productId = row.dataset.productId;
        const size = row.dataset.size || '';
        const color = row.dataset.color || '';
        const input = row.querySelector('.qty-input');
        let qty = parseInt(input.value);
        if (e.target.dataset.action === 'inc') qty++;
        else if (e.target.dataset.action === 'dec') qty = Math.max(0, qty - 1);
        input.value = qty;
        updateCartItem(productId, qty, size, color, row);
    }
});

function updateCartItem(productId, qty, size, color, row) {
    fetch('/Cart/UpdateQuantity', {
        method: 'POST',
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        body: `productId=${productId}&quantity=${qty}&size=${encodeURIComponent(size)}&color=${encodeURIComponent(color)}`
    })
        .then(r => r.json())
        .then(data => {
            if (data.success) {
                updateCartCount();
                if (qty === 0) {
                    row.style.opacity = '0';
                    row.style.transform = 'translateX(-16px)';
                    row.style.transition = 'all .3s ease';
                    setTimeout(() => row.remove(), 320);
                }
                const totalEl = document.getElementById('cart-total');
                if (totalEl) totalEl.textContent = '$' + data.total;
                const subEl = row?.querySelector('.item-subtotal');
                if (subEl && qty > 0) {
                    const price = parseFloat(row.dataset.price);
                    subEl.textContent = '$' + (price * qty).toFixed(2);
                }
            }
        });
}

function removeCartItem(productId, size, color) {
    if (!confirm('Remove this item from your bag?')) return;
    fetch('/Cart/Remove', {
        method: 'POST',
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        body: `productId=${productId}&size=${encodeURIComponent(size)}&color=${encodeURIComponent(color)}`
    })
        .then(r => r.json())
        .then(data => {
            if (data.success) { updateCartCount(); location.reload(); }
        });
}

function toggleWishlist(btn) {
    const icon = btn.querySelector('i');
    const isWished = icon.classList.contains('fas');
    icon.classList.toggle('fas', !isWished);
    icon.classList.toggle('far', isWished);
    btn.style.color = isWished ? '' : 'var(--clr-gold)';
    showToast(isWished ? 'Removed from wishlist' : 'Saved to wishlist', '♥');
}

document.addEventListener('click', function (e) {
    const thumb = e.target.closest('.thumb-img');
    if (thumb) {
        const mainImg = document.getElementById('main-product-img');
        if (mainImg) {
            mainImg.style.opacity = '0';
            mainImg.style.transform = 'scale(0.97)';
            mainImg.style.transition = 'all .28s ease';
            setTimeout(() => {
                mainImg.src = thumb.dataset.src;
                mainImg.style.opacity = '1';
                mainImg.style.transform = 'scale(1)';
            }, 280);
        }
        document.querySelectorAll('.thumb-img').forEach(t => t.classList.remove('active'));
        thumb.classList.add('active');
    }
});

document.addEventListener('change', function (e) {
    if (e.target.name === 'paymentMethod') {
        document.querySelectorAll('.payment-details').forEach(p => p.classList.add('d-none'));
        const target = document.getElementById('pay-' + e.target.value);
        if (target) target.classList.remove('d-none');
    }
});

function staggerCards() {
    document.querySelectorAll('.product-card').forEach((card, i) => {
        card.style.opacity = '0';
        card.style.transform = 'translateY(18px)';
        setTimeout(() => {
            card.style.transition = 'opacity .5s ease, transform .5s ease';
            card.style.opacity = '1';
            card.style.transform = 'translateY(0)';
        }, 80 + i * 55);
    });
}

document.addEventListener('DOMContentLoaded', function () {
    updateCartCount();
    initReveal();
    createProgressBar();
    staggerCards();
    document.querySelectorAll('[data-target]').forEach(el => counterObserver.observe(el));
});