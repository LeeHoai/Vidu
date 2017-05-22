
var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnMuaTiep').off('click').on('click', function () {
            window.location.href = "/Home/Index";
        });
        $('#btnCapNhat').off('click').on('click', function () {
            var listSanPham = $('.txtSoLuong');
            var cartList = [];
            $.each(listSanPham, function (i, item) {
                cartList.push({
                    SoLuong: $(item).val(),
                    SanPham: {
                        MaSP: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })

        });
        $('#btnXoaTatCa').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })

        });

        $('.btn-xoa').off('click').on('click', function () {
            $.ajax({
                data:{id:$(this).data('id')},
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })

        });
    }
}
cart.init();