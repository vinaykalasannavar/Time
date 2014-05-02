$(function () {
    if ($.eClock === undefined) { $.eClock = {}; }
    if ($.eClock.projects === undefined) { $.eClock.projects = {}; }

    $.eClock.projects = {
        registerModuleInputs: function (context) {
            $.eClock.projects.rebindNewModuleInputsInsert(context);
            $.eClock.projects.rebindModuleInputsChange(context);
        },
        rebindNewModuleInputsInsert: function (context) {
            var moduleInputs = $(context.moduleInputsSelector);
            //var moduleInputs = $('input[data-type="module-entry"]');
            moduleInputs.unbind('focusin').on('focusin', function (e) {
                var currentInput = $(this);
                var isLastInput = currentInput.data('last-row') != null &&
                    currentInput.data('last-row').toString() == "true";
                if (isLastInput) {
                    //insert another row.
                    $.ajax({
                        url: context.newModuleRowUrl,
                        type: 'post'
                    }).done(function (data) {
                        currentInput.data('last-row', "false");
                        var parentTr = currentInput.closest('tr');
                        var newRow = $(data);
                        newRow.insertAfter(parentTr);
                        $.eClock.projects.rebindNewModuleInputsInsert(context);
                    });
                }
            });
        },
        rebindModuleInputsChange: function (context) {
            var moduleInputs = $(context.moduleInputsSelector);
            moduleInputs.unbind('change').on('change', function (e) {
                //Add or Edit a row based on the ID of the Module
                var that = $(this);
                var moduleId = that.data('module-id');
                var newValue = that.val();
                if (newValue.length > 0) {
                    /*If the module name has been removed, 
                    then it should be deleted instead*/
                    var saveModule = {
                        Id: moduleId,
                        Name: that.val(),
                        projectId: context.projectId
                    };
                    $.ajax({
                        url: context.saveModuleUrl,
                        type: 'post',
                        data: saveModule
                    }).done(function (data) {
                        if (data.Success) {
                            if (moduleId == 0) {
                                that.data('module-id', data.NewModuleId);
                            }
                        }
                    });
                } else {
                    $.ajax({
                        url: context.deleteModuleUrl,
                        type: 'post',
                        data: { moduleId: moduleId }
                    }).done(function (data) {
                        if (data.Success) {
                            if (moduleId == 0) {
                                that.data('module-id', data.NewModuleId);
                            }
                        }
                    });
                }
            });
        }
    };

});