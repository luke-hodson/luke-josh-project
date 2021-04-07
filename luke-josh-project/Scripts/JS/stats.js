function Stats() {

    this.init = function (data) {
        this.buildPie();
        this.buildScoreboard(data);
    };

    this.buildPie = function (userData) {
        var ctx = document.getElementById('pieChart').getContext('2d');

        var data = {
            labels: ['Red', 'Orange', 'Yellow', 'Green', 'Blue'],
            datasets: [
                {
                    label: 'Dataset 1',
                    data: [12, 19, 3, 5, 2],
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.8)',
                        'rgba(54, 162, 235, 0.8)',
                        'rgba(255, 206, 86, 0.8)',
                        'rgba(75, 192, 192, 0.8)',
                        'rgba(153, 102, 255, 0.8)'
                    ],
                }
            ]
        };

        var myChart = new Chart(ctx, {
            type: 'doughnut',
            data: data,
            options: {
                responsive: false,
                plugins: {
                    legend: {
                        position: 'top',
                    },
                    title: {
                        display: true,
                        text: 'Chart.js Doughnut Chart'
                    }
                }
            },
        });        
    };

    this.buildScoreboard = function (dataobj) {
        debugger;
        var data = JSON.parse(dataobj);

        var html = `
         <table style="width:100%">
            <tr>
                <th>Name</th>
                <th>Games played</th>
                <th>Win %</th>
                <th>Total wins</th>
                <th>Total Losses</th>
                <th>Total incomings</th>
                <th>Total outgoings</th>
                <th>Profit</th>
            </tr>`;

        for (var i = 0; i < data.length; i++) {
            html += "<tr>";
            html += "<td> " + data[i].Name + "</td>";
            html += "<td> " + data[i].GamesPlayed + "</td>";
            html += "<td> " + data[i].WinPercentage + "</td>";
            html += "<td> " + data[i].TotalWins + "</td>";
            html += "<td> " + data[i].TotalLosses + "</td>";
            html += "<td> " + data[i].TotalIncomings + "</td>";
            html += "<td> " + data[i].TotalOutgoings + "</td>";
            html += "<td> " + data[i].Profit + "</td>";

            html += "</tr>";
        }

        html += "</table>";

        $('#scoreboard-container').html(html);
    };

    //this.buildLine = function (userData) {
    //    var ctx = document.getElementById('pieChart').getContext('2d');

    //    const DATA_COUNT = 5;
    //    const NUMBER_CFG = { count: DATA_COUNT, min: 0, max: 100 };

    //    const data = {
    //        labels: ['Red', 'Orange', 'Yellow', 'Green', 'Blue'],
    //        datasets: [
    //            {
    //                label: 'Dataset 1',
    //                data: [12, 19, 3, 5, 2],
    //                backgroundColor: [
    //                    'rgba(255, 99, 132, 0.8)',
    //                    'rgba(54, 162, 235, 0.8)',
    //                    'rgba(255, 206, 86, 0.8)',
    //                    'rgba(75, 192, 192, 0.8)',
    //                    'rgba(153, 102, 255, 0.8)'
    //                ],
    //            }
    //        ]
    //    };

    //    var myChart = new Chart(ctx, {
    //        type: 'doughnut',
    //        data: data,
    //        options: {
    //            responsive: false,
    //            plugins: {
    //                legend: {
    //                    position: 'top',
    //                },
    //                title: {
    //                    display: true,
    //                    text: 'Chart.js Doughnut Chart'
    //                }
    //            }
    //        },
    //    });        
}