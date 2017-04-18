$(function ($) {
    $(window).load(function () {
    });

    $('.quantity-button-inc').on('click', function () {
        $.ajax({
            type: 'POST',
            url: '/cart/addtocart',
            data: JSON.stringify({ productId: productId, quantity: quantity }),
            contentType: "application/json"
        }).done(function (data) {
            $('#shopModal').find('.modal-content').html(data);
            $('#shopModal').modal('show');
            $('.cart-badge .badge').text($('#shopModal').find('.cart-item-count').text());
        });
    })(jQuery);


});