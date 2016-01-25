$(function () {
    //$('form').on('change', 'input', function () {
    //    var inputs = $('input[id*="product"], input[id*="quanity"]');
    //    var isEmpty = false;
    //    $.each(inputs, function (i, e) {
    //        if (e.value == '') {
    //            isEmpty = true;
    //        }
    //    });
    //    if (!isEmpty && inputs.length > 0) {
    //        var number = inputs.last().attr('id').match(/\d/);
    //        number = parseInt(number) + 1;

    //        var e = $('<div class="form-group">\
    //                        <label class="control-label col-sm-1" for="product' + number + '">Składnik ' + number + ':</label>\
    //                        <div class="col-sm-4">\
    //                            <input type="text" class="form-control" id="product' + number + '" placeholder="Wpisz składnik">\
    //                        </div>\
    //                        <label class="control-label col-sm-1" for="quanity' + number + '">Ilość</label>\
    //                        <div class="col-sm-2">\
    //                            <input type="text" class="form-control" id="product' + number + '" placeholder="Wpisz ilość">\
    //                        </div>\
    //                    </div>');
    //        inputs.last().parent().parent().after(e);
    //    }
    //});
    $('form').on('click', '.bank, .card', function () {
        $(this).siblings('input').click();
    });
    $('button.ready').click(function () {
        if (!$(this).hasClass('btn-success')) {
            $(this).removeClass('btn-primary');
            $(this).addClass('btn-success');
            $(this).text('');
            $(this).append('<i class="glyphicon glyphicon-ok"></i>');
        }
    });
});