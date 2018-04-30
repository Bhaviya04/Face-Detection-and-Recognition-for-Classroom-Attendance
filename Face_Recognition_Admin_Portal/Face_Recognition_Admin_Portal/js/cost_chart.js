var morrisCharts = function () {
Morris.Donut({
element: 'morris-donut-example',
data: [
{ label: 'Direct Costs', value: 2000 },
{ label: 'Sunk Costs', value: 1000 },
{ label: 'Indirect Costs', value: 4000 },
{ label: 'Variable Costs', value: 1000 },
{ label: 'Fixed Costs', value: 8000 }
],
colors: ['#000080','#008080','#008000','#000000','#C0C0C0']
});
}();
