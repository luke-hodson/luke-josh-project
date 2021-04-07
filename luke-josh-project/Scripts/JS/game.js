function Game() {
    var _defaultHTML = "";

    this.submit = function () {
        //grab data
        var buyIn = $('#buy-in').val();       
        var winnerTakes = $('#winner-takes-all').is(":checked");       
        var selected = document.getElementById("qselected").getElementsByClassName("hidden-selected");

        var userIds = [];
        for (var i = 0; i < selected.length; i++) {
            userIds.push(selected[i].value);
        }

        var data = { "order": JSON.stringify(userIds), "buyIn": parseInt(buyIn), "winnerTakes": winnerTakes };

        //post to controller
        this.success = function (data) {
            $('#buy-in').val('');
            $('#winner-takes-all').prop('checked', false);            
            alert('added');
        };

        site.ajax("/Poker/AddGameResult", data, this.success);
    };

    this.buildDraggable = function () {
        $("#qselected").sortable();
        $("#qselected").disableSelection();

        $(".qitem").draggable({
            containment: "#container",
            helper: 'clone',
            revert: 'invalid'
        });

        $("#qselected, #qlist").droppable({
            hoverClass: 'ui-state-highlight',
            accept: ":not(.ui-sortable-helper)",
            drop: function (ev, ui) {
                $(ui.draggable).clone().appendTo(this);
                $(ui.draggable).remove();
            }
        });

        _defaultHTML = $('#drag-html').html();
    };

    this.resetDraggable = function () {
        $('#drag-html').html(_defaultHTML);
        this.buildDraggable();
    };  
}