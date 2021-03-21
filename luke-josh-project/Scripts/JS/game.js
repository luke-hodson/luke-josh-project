function Game() {
    this.submit = function () {
        debugger;
        var buyIn = $('#buy-in').val();
        var winnerTakes = $('#winner-takes-all').is("checked")
        var order = JSON.stringify($("#sortable").sortable("toArray"));

        var data = { "order": order, "buyIn": parseInt(buyIn), "winnerTakes": winnerTakes };

        this.success = function (data) {
            debugger;
        };

        site.ajax("/Poker/AddGame", data, this.success);
    };
}