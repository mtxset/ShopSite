(function ($) {
    $(window).load(function () {
    });

    $('.product-attrs li').on('click', function () {
        var $variationDiv,
            selectedproductOptions = [],
            variationName,
            $form = $(this).closest("form"),
            $attrOptions = $form.find('.product-attr-options');

        $(this).find('input').prop('checked', true);

        $attrOptions.each(function () {
            selectedproductOptions.push($(this).find('input[type=radio]:checked').val());
        });
        variationName = selectedproductOptions.join('-');
        $variationDiv = $('div.' + variationName);
        $('.product-variation').hide();
        if ($variationDiv.length > 0) {
            $variationDiv.show();
            $('.product-variation-notavailable').hide();
        } else {
            $('.product-variation-notavailable').show();
        }
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