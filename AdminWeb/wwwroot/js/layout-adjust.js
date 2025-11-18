// Dynamically adjust header height offset for main content
(function(){
  function setHeaderHeight(){
    var header = document.querySelector('header');
    if(!header) return;
    var h = header.getBoundingClientRect().height;
    var mt = parseFloat(getComputedStyle(header).marginTop)||0;
    // extra spacing 8px
    var total = h + mt + 8;
    document.documentElement.style.setProperty('--header-height', total + 'px');
  }
  window.adjustLayout = setHeaderHeight;
  window.addEventListener('resize', setHeaderHeight);
  document.addEventListener('DOMContentLoaded', setHeaderHeight);
})();