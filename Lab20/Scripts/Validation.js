$(function () {
    $("#AddUser").validate({
        rules: {
            FirstName: {
                required: true
            },
            LastName: {
                required: true
            },
            Email: {
                required: true,
                email: true
            },
            PWord: {
                required: true
            },
            PWordConfirm: {
                required: true,
                equalTo: "#PWord"
            },
            Position: {
                required:true
            },
            JerseyNum: {
                number: true //needs work - how to make it between 1-99?
            }
        },
        messages: {
            Email: {
                required: 'Please enter an email address',
                email: 'Please enter a <em>valid</em> email address.'
            },
            PWordConfirm: {
                equalTo: 'Passwords do not match.'
            },
            Position: {
                required: 'Please select your position.'
            }
        }
    });
});

if (!$('input[name=Position]:checked').val()) {
    alert: 'Please select a position';
}
