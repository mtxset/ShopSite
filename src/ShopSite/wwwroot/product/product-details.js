(function ($) {
    $(window).load(function () {
    });

    $('.quantity-button').on('click', function () {
        var quantityInput = $(this).closest("form").find('.quantity-field');
        if ($(this).val() === '+') {
            quantityInput.val(parseInt(quantityInput.val(), 10) + 1);
        }
        else if (quantityInput.val() > 1) {
            quantityInput.val(quantityInput.val() - 1);
        }
    });
})(jQuery);