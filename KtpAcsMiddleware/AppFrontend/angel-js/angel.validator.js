angel.validator = (function($) {
    var $mainForm;
    var $errorContainer;
    var $errorLabelContainer;

    var isSubmitted = false;
    var isPartial = false;

    var errorLabelContainerTemplate = "<ul style='margin-bottom: 0'></ul>";
    var errorLabelTemplate = "<li><label>{0}</label></li>";

    var errorMessageSettings = {
        required: "Please input all required fields. Please review the highlighted fields below."
    };

    var errorMessages = [];

    var isRepeated = function(message) {
        for (var index = 0; index < errorMessages.length; index++) {
            if (errorMessages[index] == message) {
                return true;
            }
        }
        return false;
    };

    var clearMessages = function() {
        errorMessages.length = 0;
    };

    var buildErrorMessages = function(errorList) {
        if (!isPartial) {
            clearMessages();
        }
        $.each(errorList,
            function() {
                var errorMessage = this.message;
                if (!isRepeated(errorMessage)) {
                    errorMessages.push(errorMessage);
                }
            });
    };

    var highlight = function(element) {
        if (element.type == "radio") {
            $(element.form).find('input[name="' + element.name + '"]').each(function(i, elem) {
                $(elem.form).find('label[for="' + elem.id + '"]').addClass("highlight");
            });
        } else if (element.type == "checkbox") {
            $(element.form).find('input[group="' + $(element).attr("group") + '"]').each(function(i, elem) {
                $(elem.form).find('label[for="' + elem.id + '"]').addClass("highlight");
            });
        } else {
            $(element).addClass("highlight");
        }
    };

    var unhighlight = function(element) {
        if (element.type == "radio") {
            $(element.form).find('input[name="' + element.name + '"]').each(function(i, item) {
                $(item.form).find('label[for="' + item.id + '"]').removeClass("highlight");
            });
        } else if (element.type == "checkbox") {
            $(element.form).find('input[group="' + $(element).attr("group") + '"]').each(function(i, elem) {
                $(elem.form).find('label[for="' + elem.id + '"]').removeClass("highlight");
            });
        } else {
            $(element).removeClass("highlight");
        }
    };

    var invalidHandler = function() {
        isSubmitted = true;
    };

    var errorPlacement = function() {
    };

    var showErrors = function(errorMap, errorList) {
        if (!$errorContainer) {
            return;
        }
        if (isSubmitted || isPartial) {
            buildErrorMessages(errorList);

            $errorLabelContainer.empty();
            for (var index = 0; index < errorMessages.length; index++) {
                $errorLabelContainer.append($.format(errorLabelTemplate, errorMessages[index]));
            }

            if (errorMessages.length > 0) {
                $errorContainer.show();
            } else {
                $errorContainer.hide();
            }

            isSubmitted = false;
        }

        this.defaultShowErrors();
    };

    var initializeErrorLabelContainer = function() {
        if (!$errorContainer) {
            return;
        }
        $errorContainer.empty();
        $errorContainer.append(errorLabelContainerTemplate);
        $errorLabelContainer = $("ul", $errorContainer);
    };

    var that = {};

    that.initialize = function() {
        if (!$("#mainForm")) {
            return;
        }
        $mainForm = $("#mainForm");

        initializeErrorLabelContainer();
        $.validator.messages.required = errorMessageSettings.required;
        $.validator.setDefaults({
            highlight: highlight,
            unhighlight: unhighlight,
            invalidHandler: invalidHandler,
            errorPlacement: errorPlacement,
            showErrors: showErrors
        });
        $mainForm.validate();
    };

    that.setMessageSettings = function(messages) {
        for (var index = 0; index < messages.length; index++) {
            var message = messages[index];
            errorMessageSettings[message.key] = message.value;
        }
    };

    that.getRequiredMessage = function() {
        return errorMessageSettings.required;
    };

    that.validate = function($elements, $substitutedContainer) {
        if ($elements == null) {
            $elements = $mainForm.find(":input:not(:hidden)");
        } else if ($elements.length == 1 && $elements.find(":input:not(:hidden)")) {
            $elements = $elements.find(":input:not(:hidden)");
        }
        if (!$elements) {
            return true;
        }
        var $defaultErrorContainer = $errorContainer;
        var $defaultLabelContainer = $errorLabelContainer;
        if ($substitutedContainer) {
            $errorContainer = $substitutedContainer;
            initializeErrorLabelContainer();
        }
        isPartial = true;
        clearMessages();

        $elements.each(function() {
            $(this).change(function() {
                $substitutedContainer.fadeOut(1000,
                    function() {
                        $substitutedContainer.empty();
                    });
            });
        });

        var isValid = $elements.valid();

        $errorContainer = $defaultErrorContainer;
        $errorLabelContainer = $defaultLabelContainer;
        isPartial = false;

        return isValid;
    };

    that.clearMessages = function($elements, $substitutedContainer) {
        $elements.each(function() {
            unhighlight($(this));
        });
        $substitutedContainer.hide();
    };
    return that;
})(jQuery);