$(document).ready(function () {
	var c = document.getElementById("StockGraph");
	var ctx = c.getContext("2d");
	var grd = ctx.createLinearGradient(0, 0, 300, 0);
	grd.addColorStop(0, "blue");
	grd.addColorStop(1, "black");
	ctx.fillStyle = grd;
	ctx.fillRect(20, Math.random() * 200, 20, 200);
	ctx.fillRect(80, Math.random() * 200, 20, 200);
	ctx.fillRect(140, Math.random() * 200, 20, 200);
	ctx.fillRect(200, Math.random() * 200, 20, 200);
});