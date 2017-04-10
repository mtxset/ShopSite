(function ($) {
    $(window).load(function () {
    });

    $('.quantity-button-inc').on('click', function () {
        $.ajax({
            type: 'POST',
            url: '/cart/addtocart',
            data: JSON.stringify({ productId: productId, quantity: quantity }),
            contentType: "application/json"
    });
})(jQuery);