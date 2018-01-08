var SanPhamController = new Object();

SanPhamController.deleteProduct = function () {
    var deleteProduct = function (e) {
        
        debugger;
        e.preventDefault();
        var link = $(e.target);
        var result = confirm("Are You Sure!");
        if (result === true) {
            $.ajax({
                url: "/api/sanphams/" + link.attr("data-product-id"),
                type: "DELETE",
                success: function() {
                    link.parents("tr").fadeOut(function() {
                        $(this).remove();
                    });
                },
                error: function(request, textStatus, error) {
                    alert("Something fail " + error);
                }
            });
        }
    }

    var productConstructor = function() {
        debugger;
        $(".js-delete-product").on("click", deleteProduct);
    }


    return {
        init: productConstructor
    }
}();

SanPhamController.addProduct = function () {

    var add = function() {
        $("#createSP").submit(function (e) {
            e.preventDefault();
            var sanPham = new Object();
            sanPham.TenSanPham = $("input[name='txtTenSanPham']").val();
            sanPham.GiaSanPham = $("input[name='txtGiaSP']").val();

            $.post("/api/SanPhams", sanPham)
                .done(function (maSanPham) {
                    debugger;
                    //alert("Them san pham thanh cong!");
                    var actionLink = "<a href='#' class='js-delete-product' data-product-id="+maSanPham+"> Delete </a>";
                    var rowData = "<tr><td>" + sanPham.TenSanPham + "</td><td>" + sanPham.GiaSanPham + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>"+actionLink+"</td></tr>";
                    $(".table tbody").prepend(rowData);
                    SanPhamController.deleteProduct.init();
                })
                .fail(function () {
                    alert("something fail!");
                });
        });
    }

    return {
        init: add
    }

}();