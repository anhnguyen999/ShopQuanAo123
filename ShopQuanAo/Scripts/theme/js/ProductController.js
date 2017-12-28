var ProductController = function() {

    var deleteProduct = function(e) {
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