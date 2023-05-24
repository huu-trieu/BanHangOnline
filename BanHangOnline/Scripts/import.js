import AutoNumeric from 'autonumeric';

const autoNumericOptions = {
    digitGroupSeparator: ',',
    decimalCharacter: '.',
    decimalPlaces: 2,
    unformatOnSubmit: true,
    watchExternalChanges: true,
    modifyValueOnWheel: false,
};

$('.auto').each(function () {
    new AutoNumeric(this, autoNumericOptions);
});

$('#demoPrice').on('blur focusout keypress keyup', function () {
    var demoGet = AutoNumeric.get('#demoPrice');
    $('#Price').val(demoGet);
    AutoNumeric.set('#Price', demoGet);
});

$('#demoPriceSale').on('blur focusout keypress keyup', function () {
    var demoGet = AutoNumeric.get('#demoPriceSale');
    $('#PriceSale').val(demoGet);
    AutoNumeric.set('#PriceSale', demoGet);
});
