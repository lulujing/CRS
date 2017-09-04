$(window).on('load', function () {

    $('.selectpicker').selectpicker({
        //'selectedText': 'cat'
    });
    $('.selectpicker').change(function () {
        var selectString = $("#id_select").find("option:selected").map(function (index, elem) {
            return $(elem).val();
        }).get().join(',');
        $.ajax({
            type: 'post',
            url:' @Url.Action("FilterList","Home")',
            data: { 'skillsString': selectString},
            dataType: "json",
            success: function (data) {
                $('#list').load("/Home/ListChange", data);
            },
            error: function (err) {
                alert('erro');
            }
        });
       
    });
    $('#btn-add-Candidate').click(function (e) {
        $('#login-form-body').load("@Url.Action("AddNewCandidate","Home")",
             function () {
                 $('#login-form').modal('show');
             });
    });

});