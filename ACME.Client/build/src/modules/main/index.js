import { Utils } from "lymph-client";
//jQuery.ajax("http://localhost:4000/api/greeting", {}).then(function (response) {
//    $("#message").html(response.text);
//});
var handleErrors = function (errorMessage) {
    if (!errorMessage) {
        $("#error-message").hide();
    }
    else {
        $("#error-message").text(JSON.stringify(errorMessage.responseText)).show();
    }
};
var fetchGamesAndUpdate = function () {
    jQuery.ajax("http://localhost:4000/api/games", {}).then(function (data) {
        console.log(data);
        var rollList = data.map(function (game) { return "<li>" + game.frames + "</li>"; });
        $("#game-history").html(rollList);
    });
};
$("#bowling-score-form").on("submit", function (e) {
    e.preventDefault();
    var score = Utils.extractFormData(this).score;
    jQuery.post("http://localhost:4000/api/games/" + score)
        .then(function (response) {
        fetchGamesAndUpdate();
    })
        .catch(function (error) {
        handleErrors(error);
    });
});
fetchGamesAndUpdate();
handleErrors("");
