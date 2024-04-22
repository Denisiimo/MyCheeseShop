/*document.addEventListener('DOMContentLoaded', function () {
	const signInBtn = document.getElementById("signIn");
	const signUpBtn = document.getElementById("signUp");
	const fistForm = document.getElementById("form1");
	const secondForm = document.getElementById("form2");
	const container = document.getElementById("main");

	signInBtn.addEventListener("click", () => {
		container.classList.remove("right-panel-active");
		console.log("Hey1");
	});

	signUpBtn.addEventListener("click", () => {
		container.classList.add("right-panel-active");
		console.log("Hey2");
	});

	fistForm.addEventListener("submit", (e) => e.preventDefault());
	secondForm.addEventListener("submit", (e) => e.preventDefault());
});