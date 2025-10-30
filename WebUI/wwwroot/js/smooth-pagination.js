// Smooth Scroll Functions for Pagination
window.smoothScrollToElement = (selector) => {
    try {
        const element = document.querySelector(selector);
        if (element) {
            element.scrollIntoView({
                behavior: 'smooth',
                block: 'start',
                inline: 'nearest'
            });
            return true;
        }
        return false;
    } catch (error) {
        console.error('Smooth scroll error:', error);
        return false;
    }
};

// Enhanced smooth scroll with offset
window.smoothScrollToElementWithOffset = (selector, offset = 80) => {
    try {
        const element = document.querySelector(selector);
        if (element) {
            const elementPosition = element.getBoundingClientRect().top;
            const offsetPosition = elementPosition + window.pageYOffset - offset;

            window.scrollTo({
                top: offsetPosition,
                behavior: 'smooth'
            });
            return true;
        }
        return false;
    } catch (error) {
        console.error('Smooth scroll with offset error:', error);
        return false;
    }
};

// Utility function to add loading class temporarily
window.addTemporaryLoadingClass = (selector, duration = 300) => {
    try {
        const element = document.querySelector(selector);
        if (element) {
            element.classList.add('loading');
            setTimeout(() => {
                element.classList.remove('loading');
            }, duration);
        }
    } catch (error) {
        console.error('Add loading class error:', error);
    }
};

// Check if user prefers reduced motion
window.prefersReducedMotion = () => {
    return window.matchMedia('(prefers-reduced-motion: reduce)').matches;
};

// Initialize intersection observer for product cards animation
window.initializeProductAnimation = () => {
    if (window.prefersReducedMotion()) {
        return; // Skip animations if user prefers reduced motion
    }

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('animate-in');
            }
        });
    }, {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    });

    // Observe all product cards
    document.querySelectorAll('.product-card').forEach(card => {
        observer.observe(card);
    });
};

// Enhanced scroll to top function
window.scrollToTop = (smooth = true) => {
    if (smooth && !window.prefersReducedMotion()) {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    } else {
        window.scrollTo(0, 0);
    }
};

// Debounce function for performance
window.debounce = (func, wait) => {
    let timeout;
    return function executedFunction(...args) {
        const later = () => {
            clearTimeout(timeout);
            func(...args);
        };
        clearTimeout(timeout);
        timeout = setTimeout(later, wait);
    };
};

// Initialize when DOM is ready
document.addEventListener('DOMContentLoaded', () => {
    // Add smooth scroll behavior to html element if not already set
    if (!document.documentElement.style.scrollBehavior) {
        document.documentElement.style.scrollBehavior = 'smooth';
    }
    
    // Initialize product animations
    window.initializeProductAnimation();
});

// Re-initialize animations when new content loads (for SPA)
window.reinitializeAnimations = () => {
    setTimeout(() => {
        window.initializeProductAnimation();
    }, 100);
};