function Stats() {
    this.buildPie = function (userData) {
        var ctx = document.getElementById('pieChart').getContext('2d');

        const DATA_COUNT = 5;
        const NUMBER_CFG = { count: DATA_COUNT, min: 0, max: 100 };

        const data = {
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