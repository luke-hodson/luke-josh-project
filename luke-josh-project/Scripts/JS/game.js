function Game() {
    this.submit = function () {
        //grab data
        var buyIn = $('#buy-in').val();       
        var winnerTakes = $('#winner-takes-all').is(":checked");
        var order = JSON.stringify($("#sortable").sortable("toArray"));

        var data = { "order": order, "buyIn": parseInt(buyIn), "winnerTakes": winnerTakes };

        //post to controller
        this.success = function (data) {
            $('#buy-in').val('');
            $('#winner-takes-all').prop('checked', false);            
            alert('dope');
        };

        site.ajax("/Poker/AddGameResult", data, this.success);
    };
}