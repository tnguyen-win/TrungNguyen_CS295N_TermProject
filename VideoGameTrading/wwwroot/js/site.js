// jshint esversion: 6

// Perfect body cover height
function calculateHeight() {
	let height1 = document.getElementsByTagName("header")[0].offsetHeight;
	let hasMargin = document.getElementsByTagName("main")[0].children[0].classList.contains("mt-5");

	document.getElementsByTagName("main")[0].style.height = hasMargin ? `calc(100vh - ${height1}px - 3rem)` : `calc(100vh - 3rem)`;
}

window.addEventListener("load", calculateHeight);
window.addEventListener("scroll", calculateHeight);