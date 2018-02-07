jQuery.ajax("http://localhost:8081/api/greeting", {}).then(function (response) {
    $("#message").html(response.text)
})