(function($) {
    $.validator.addMethod("customPassword",
        function(value, element) {
            return this.optional(element) || value.match(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$/);
        },
        "Please input valid password value.");

    $.validator.addMethod("cnMobile",
        function(value, element) {
            return this.optional(element) || value.match(/^1[0-9]{10}$/);
        },
        "Please input valid mobile value.");

    $.validator.addMethod("isIdentityCode",
        function(value, element) {
            if (this.optional(element)) {
                return true;
            }
            return $(element).isIdentityCode();
        },
        "Please input valid password value.");

    $.validator.addMethod("judgePDF",
        function(value, element) {
            if (this.optional(element)) {
                return true;
            }

            var ext = value.substr(value.lastIndexOf("\\") + 1).split(".")[1].toLowerCase();
            if (ext != "pdf") return false;
            return true;
        },
        "You must select a PDF document.");

    $.validator.addMethod("judgeCSV",
        function(value, element) {
            if (this.optional(element)) {
                return true;
            }

            var ext = value.substr(value.lastIndexOf("\\") + 1).split(".")[1].toLowerCase();
            if (ext != "csv") return false;
            return true;
        },
        "You must select a CSV file.");

    $.validator.addMethod("unique",
        function(value, element, param) {
            if (this.optional(element)) {
                return true;
            }

            var compareValues = param;

            for (var index = 0; index < compareValues.length; index++) {
                if (value.toLowerCase() === compareValues[index].toLowerCase()) {
                    return false;
                }
            }

            return true;
        },
        "Please input an unique value.");

    $.validator.addMethod("compareDateFromTo",
        function(value, element, param) {
            if (this.optional(element)) {
                return true;
            }

            if (!param[0].val() || !param[1].val()) {
                return true;
            }
            var date = param[0].val().split("-");
            var year = parseInt(date[0], 10);
            var month = parseInt(date[1], 10) - 1;
            var day = parseInt(date[2], 10);

            var dateContrast = param[1].val().split("-");
            var yearContrast = parseInt(dateContrast[0], 10);
            var monthContrast = parseInt(dateContrast[1], 10) - 1;
            var dayContrast = parseInt(dateContrast[2], 10);

            var dateValue = new Date(year, month, day);
            var contrastValue = new Date(yearContrast, monthContrast, dayContrast);

            if (dateValue > contrastValue) {
                return false;
            }

            return true;
        },
        "Please input a valid date range.");

})(jQuery);