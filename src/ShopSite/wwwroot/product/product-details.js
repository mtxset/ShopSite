(function ($) {
    $(window).load(function () {
    });

    $('.quantity-button').on('click', function () {
        var quantityInput = document.getElementsByClassName("quantity-field");
        if ($(this).val() === '+') {
            quantityInput.Quantity.value = (parseInt(quantityInput.Quantity.value, 10) + 1);
        }
        else if (quantityInput.Quantity.value > 1) {
            quantityInput.Quantity.value = (quantityInput.Quantity.value - 1);
        }
    });
})(jQuery);