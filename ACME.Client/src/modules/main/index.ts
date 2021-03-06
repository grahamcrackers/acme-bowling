﻿import { Utils } from "lymph-client"

//jQuery.ajax("http://localhost:4000/api/greeting", {}).then(function (response) {
//    $("#message").html(response.text);
//});
const handleErrors = function (errorMessage) {
    if (!errorMessage) {
        $("#error-message").hide();
    } else {
        $("#error-message").text(JSON.stringify(errorMessage.responseText)).show();
    }
    
};

const fetchGamesAndUpdate = function () {

    jQuery.ajax("http://localhost:4000/api/games", {}).then(function (data) {
        console.log(data);
        const rollList = data.map(
            game => `<li>${game.frames}</li>`);

        $("#game-history").html(rollList);
    })
}

$("#bowling-score-form").on("submit", function (e) {
    e.preventDefault();

    const { score } = Utils.extractFormData(this);

    jQuery.post(`http://localhost:4000/api/games/${score}`)
          .then((response) => {
            fetchGamesAndUpdate();
          })
          .catch((error) => {
            handleErrors(error);
          })
});

fetchGamesAndUpdate();
handleErrors("");