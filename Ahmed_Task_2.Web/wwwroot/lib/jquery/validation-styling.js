// jQuery unobtrusive validation defaults

$.validator.setDefaults({
    errorClass: "",
    validClass: "",

    highlight: function (element, errorClass, validClass) {
        $(element).addClass("is-invalid").removeClass("is-valid");
        $(element.form).find('[data-valmsg-for="' + element.name + '"]').addClass("invalid-feedback");
    },

    unhighlight: function (element, errorClass, validClass) {
        $(element).addClass("is-valid").removeClass("is-invalid");
        $(element.form).find('[data-valmsg-for="' + element.name + '"]').removeClass("invalid-feedback");
    },
});