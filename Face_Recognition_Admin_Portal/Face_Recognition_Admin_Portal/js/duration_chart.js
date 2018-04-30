var morrisCharts = function () {
Morris.Donut({
element: 'morris-donut-example',
data: [
{ label: 'Requirements', value: 80 },
{ label: 'Design', value: 17 },
{ label: 'Coding', value: 55 },
{ label: 'Testing', value: 16 },
{ label: 'Deployment', value: 6 }
],
colors: ['#000080','#008080','#008000','#000000','#C0C0C0']
});
}();
