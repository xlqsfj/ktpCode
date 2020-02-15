$(document).ready(function() {
    var $workerId = $("#workerId");
    var $identityAuthenticationButton = $("#identityAuthenticationButton");
    var $closeButton = $("#closeButton");
    $identityAuthenticationButton.click(function() {
        var workerId = $workerId.val();
        $.getJSON("GetTeamWorker?id=" + workerId,
            function(result) {
                angel.workerIdentityAuthenticationControl.show(result,
                    function() {
                        var newAuthentication = angel.workerIdentityAuthenticationControl.newItem();
                        angel.ajaxPost("PutWorkerAuthentication",
                            { dto: newAuthentication, id: workerId },
                            function(data) {
                                var result = $.parseJSON(data);
                                if (result.result == 0) {
                                    angel.alert("认证信息保存成功",
                                        function() {
                                            angel.workerIdentityAuthenticationControl.hide();
                                            angel.reloadPage();
                                        });
                                } else {
                                    angel.alert(result.resultValue);
                                }
                            });
                    });
            });
    });

    $closeButton.click(function() {
        window.close();
    });
});