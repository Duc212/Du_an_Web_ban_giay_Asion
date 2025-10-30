// Auth JavaScript Functions
window.addAuthPageClass = () => {
    document.body.classList.add('auth-page');
};

window.focusElement = (element) => {
    if (element) {
        element.focus();
    }
};

window.addShakeAnimation = (element) => {
    if (element) {
        element.classList.add('shake');
        setTimeout(() => {
            element.classList.remove('shake');
        }, 500);
    }
};

window.handleOtpPaste = (container, dotnetRef) => {
    const inputs = container.querySelectorAll('.otp-input');
    
    inputs.forEach((input, index) => {
        input.addEventListener('paste', async (e) => {
            e.preventDefault();
            const pastedData = e.clipboardData.getData('text');
            await dotnetRef.invokeMethodAsync('SetOtpFromPaste', pastedData);
        });
    });
};

window.playSuccessAnimation = (element) => {
    if (element) {
        // Add confetti effect (optional)
        createConfetti();
    }
};

// Simple confetti effect
function createConfetti() {
    const colors = ['#FF4D4D', '#48BB78', '#ED8936', '#4299E1'];
    const confettiCount = 50;
    
    for (let i = 0; i < confettiCount; i++) {
        createConfettiPiece(colors[Math.floor(Math.random() * colors.length)]);
    }
}

// Setup click outside to close dropdown
window.setupDropdownClickOutside = (dotnetRef) => {
    document.addEventListener('click', (event) => {
        const dropdownContainer = event.target.closest('.user-dropdown-container');
        if (!dropdownContainer) {
            // Click was outside dropdown, close it
            dotnetRef.invokeMethodAsync('CloseDropdownFromJS');
        }
    });
};

function createConfettiPiece(color) {
    const confetti = document.createElement('div');
    confetti.style.position = 'fixed';
    confetti.style.width = '10px';
    confetti.style.height = '10px';
    confetti.style.backgroundColor = color;
    confetti.style.left = Math.random() * 100 + 'vw';
    confetti.style.top = '-10px';
    confetti.style.zIndex = '9999';
    confetti.style.pointerEvents = 'none';
    confetti.style.borderRadius = '50%';
    
    document.body.appendChild(confetti);
    
    const animation = confetti.animate([
        { transform: 'translateY(0) rotate(0deg)', opacity: 1 },
        { transform: `translateY(100vh) rotate(360deg)`, opacity: 0 }
    ], {
        duration: Math.random() * 2000 + 1000,
        easing: 'ease-out'
    });
    
    animation.onfinish = () => {
        confetti.remove();
    };
}