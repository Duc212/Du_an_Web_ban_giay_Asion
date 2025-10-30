// Toast Service JavaScript
window.toastService = {
    dotNetRef: null,

    initialize: function (dotNetRef) {
        this.dotNetRef = dotNetRef;
    },

    showSuccess: function (message) {
        if (this.dotNetRef) {
            this.dotNetRef.invokeMethodAsync('ShowToast', message, 'Success');
        }
    },

    showError: function (message) {
        if (this.dotNetRef) {
            this.dotNetRef.invokeMethodAsync('ShowToast', message, 'Error');
        }
    },

    showWarning: function (message) {
        if (this.dotNetRef) {
            this.dotNetRef.invokeMethodAsync('ShowToast', message, 'Warning');
        }
    },

    showInfo: function (message) {
        if (this.dotNetRef) {
            this.dotNetRef.invokeMethodAsync('ShowToast', message, 'Info');
        }
    }
};