$(function () {
	$.ajax({
		url: '/Home/FillTable',
		type: 'GET',
		dataType: 'json',
		cache: false,
		success: function (model) {
			console.log(model.itemcount);
			$("#showtable tbody").html("");

			$.each(model.productlist, function (index, value) {
				var result = "<tr><td><input type=\"checkbox\" data-id=" + value.ID + ">" + "</td><td>" + value.ProductName + "</td><td>" + value.Price + "</td><td>" + value.Country + "</td></tr>";
				$(result).appendTo("#showtable tbody");
			});

			if (model.itemcount > 1) {
				var result = "<li class=\"page-item\"><a class=\"page-link\" href=\"#\" tabindex=\"-1\">PREVIOUS</a></li>";
				$(result).appendTo(".pagination");
				for (i = 1; i <= model.itemcount; i++) {
					var result = "<li class=\"page-item\"><a class=\"page-link\" href=\"#\" tabindex=\"-1\">" + i + "</a></li>";
					$(result).appendTo(".pagination");
				}
				var result = "<li class=\"page-item\"><a class=\"page-link\" href=\"#\" tabindex=\"-1\">NEXT</a></li>";
				$(result).appendTo(".pagination");
			}

		}
	});

	$("#search").keyup(function () {
		$.ajax({
			url: 'http://localhost:58611/Home/FillTable',
			type: 'POST',
			data: { search: $("#search").val(), num: $("#showrows").val(), page: 1 },
			success: function (model) {
				console.log(model.itemcount);
				$("#showtable tbody").html("");

				$.each(model.productlist, function (index, value) {
					var result = "<tr><td><input type=\"checkbox\" data-id=" + value.ID + ">" + "</td><td>" + value.ProductName + "</td><td>" + value.Price + "</td><td>" + value.Country + "</td></tr>";
					$(result).appendTo("#showtable tbody");
				});

				$(".pagination").html("");

				if (model.itemcount > 1) {
					var result = "<li class=\"page-item\"><a class=\"page-link\" href=\"#\" tabindex=\"-1\">PREVIOUS</a></li>";
					$(result).appendTo(".pagination");
					for (i = 1; i <= model.itemcount; i++) {
						var result = "<li class=\"page-item\"><a class=\"page-link\" href=\"#\" tabindex=\"-1\">" + i + "</a></li>";
						$(result).appendTo(".pagination");
					}
					var result = "<li class=\"page-item\"><a class=\"page-link\" href=\"#\" tabindex=\"-1\">NEXT</a></li>";
					$(result).appendTo(".pagination");
				}
			}
		});
	});

	$("#Saveselected").click(function () {
		var count = 0;
		var elements = document.querySelectorAll('input[data-id]');
		var linka = "/Home/GetSelectedExcel?"
		elements.forEach(element => {
			if (element.checked) {
				linka += "id=" + element.getAttribute("data-id") + "&"
				++count;
			}
		});
		if (count > 0) {
			var link = document.createElement("a");
			link.href = linka;
			link.click();
			link.remove;
		}
		else {
			alert("Please select some rows");
		}
	});




	$("#showrows").change(function () {
		$.ajax({
			url: 'http://localhost:58611/Home/FillTable',
			type: 'POST',
			data: { search: $("#search").val(), num: $("#showrows").val(), page: 1 },
			success: function (model) {
				console.log(model.itemcount);
				$("#showtable tbody").html("");

				$.each(model.productlist, function (index, value) {
					var result = "<tr><td><input type=\"checkbox\" data-id=" + value.ID + ">" + "</td><td>" + value.ProductName + "</td><td>" + value.Price + "</td><td>" + value.Country + "</td></tr>";
					$(result).appendTo("#showtable tbody");
				});

				$(".pagination").html("");

				if (model.itemcount > 1) {
					var result = "<li class=\"page-item\"><a class=\"page-link\" href=\"#\" tabindex=\"-1\">PREVIOUS</a></li>";
					$(result).appendTo(".pagination");
					for (i = 1; i <= model.itemcount; i++) {
						var result = "<li class=\"page-item\"><a class=\"page-link\" href=\"#\" tabindex=\"-1\">" + i + "</a></li>";
						$(result).appendTo(".pagination");
					}
					var result = "<li class=\"page-item\"><a class=\"page-link\" href=\"#\" tabindex=\"-1\">NEXT</a></li>";
					$(result).appendTo(".pagination");
				}
			}
		});
	});

});