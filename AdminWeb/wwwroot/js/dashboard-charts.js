// Dashboard Charts using real API data
let revenueChart = null;
let ordersChart = null;
let topProductsChart = null;
let customerGrowthChart = null;

window.initDashboardCharts = function(statisticsData) {
    if (!statisticsData) {
        console.warn('No statistics data provided');
        return;
    }
    
    console.log('Statistics data received:', statisticsData);

    // Destroy existing charts to prevent memory leaks
    if (revenueChart) revenueChart.destroy();
    if (ordersChart) ordersChart.destroy();
    if (topProductsChart) topProductsChart.destroy();
    if (customerGrowthChart) customerGrowthChart.destroy();

    // 1. Revenue Chart (Line Chart) - Use PascalCase from C#
    initRevenueChart(statisticsData.DailyOrders || []);

    // 2. Orders by Status Chart (Doughnut Chart)
    initOrdersStatusChart(statisticsData);

    // 3. Top Products Chart (Bar Chart) - Use PascalCase from C#
    initTopProductsChart(statisticsData.TopProducts || []);

    // 4. Customer Growth Chart (Line Chart with Area) - Use PascalCase from C#
    initCustomerGrowthChart(statisticsData.CustomerGrowth || [], statisticsData.DailyOrders || []);
};

function initRevenueChart(dailyOrders) {
    const ctx = document.getElementById('revenueChart');
    if (!ctx) return;
    
    console.log('Revenue chart data:', dailyOrders);

    const labels = dailyOrders.map(d => {
        const date = new Date(d.Date); // PascalCase from C#
        return `${date.getDate()}/${date.getMonth() + 1}`;
    });
    
    const data = dailyOrders.map(d => d.Revenue); // PascalCase from C#

    revenueChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Doanh thu (₫)',
                data: data,
                borderColor: 'rgb(99, 102, 241)',
                backgroundColor: 'rgba(99, 102, 241, 0.1)',
                tension: 0.4,
                fill: true,
                pointRadius: 4,
                pointHoverRadius: 6,
                pointBackgroundColor: 'rgb(99, 102, 241)',
                pointBorderColor: '#fff',
                pointBorderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    display: true,
                    position: 'top'
                },
                tooltip: {
                    backgroundColor: 'rgba(0, 0, 0, 0.8)',
                    padding: 12,
                    cornerRadius: 8,
                    callbacks: {
                        label: function(context) {
                            return 'Doanh thu: ₫' + context.parsed.y.toLocaleString('vi-VN');
                        }
                    }
                }
            },
            scales: {
                y: {
                    beginAtZero: true,
                    ticks: {
                        callback: function(value) {
                            return '₫' + (value / 1000000).toFixed(0) + 'M';
                        }
                    },
                    grid: {
                        color: 'rgba(0, 0, 0, 0.05)'
                    }
                },
                x: {
                    grid: {
                        display: false
                    }
                }
            }
        }
    });
}

function initOrdersStatusChart(statistics) {
    const ctx = document.getElementById('ordersChart');
    if (!ctx) return;
    
    console.log('Orders status data:', statistics);

    const data = [
        statistics.PendingOrders || 0,     // PascalCase from C#
        statistics.ConfirmedOrders || 0,   // PascalCase from C#
        statistics.ShippingOrders || 0,    // PascalCase from C#
        statistics.DeliveredOrders || 0,   // PascalCase from C#
        statistics.CancelledOrders || 0    // PascalCase from C#
    ];

    ordersChart = new Chart(ctx, {
        type: 'doughnut',
        data: {
            labels: ['Chờ xác nhận', 'Đã xác nhận', 'Đang giao', 'Đã giao', 'Đã hủy'],
            datasets: [{
                data: data,
                backgroundColor: [
                    'rgb(251, 191, 36)',  // yellow - pending
                    'rgb(59, 130, 246)',  // blue - confirmed
                    'rgb(168, 85, 247)',  // purple - shipping
                    'rgb(34, 197, 94)',   // green - delivered
                    'rgb(239, 68, 68)'    // red - cancelled
                ],
                borderWidth: 2,
                borderColor: '#fff',
                hoverOffset: 10
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    position: 'bottom',
                    labels: {
                        padding: 20,
                        usePointStyle: true,
                        pointStyle: 'circle'
                    }
                },
                tooltip: {
                    backgroundColor: 'rgba(0, 0, 0, 0.8)',
                    padding: 12,
                    cornerRadius: 8,
                    callbacks: {
                        label: function(context) {
                            const total = context.dataset.data.reduce((a, b) => a + b, 0);
                            const percentage = ((context.parsed / total) * 100).toFixed(1);
                            return context.label + ': ' + context.parsed + ' (' + percentage + '%)';
                        }
                    }
                }
            }
        }
    });
}

function initTopProductsChart(topProducts) {
    const ctx = document.getElementById('topProductsChart');
    if (!ctx) return;
    
    console.log('Top products data:', topProducts);

    const top5 = topProducts.slice(0, 5);
    const labels = top5.map(p => p.ProductName.length > 20 ? p.ProductName.substring(0, 20) + '...' : p.ProductName); // PascalCase from C#
    const data = top5.map(p => p.Revenue); // PascalCase from C#

    topProductsChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Doanh thu (₫)',
                data: data,
                backgroundColor: [
                    'rgba(59, 130, 246, 0.8)',
                    'rgba(16, 185, 129, 0.8)',
                    'rgba(251, 191, 36, 0.8)',
                    'rgba(168, 85, 247, 0.8)',
                    'rgba(239, 68, 68, 0.8)'
                ],
                borderColor: [
                    'rgb(59, 130, 246)',
                    'rgb(16, 185, 129)',
                    'rgb(251, 191, 36)',
                    'rgb(168, 85, 247)',
                    'rgb(239, 68, 68)'
                ],
                borderWidth: 2,
                borderRadius: 8,
                borderSkipped: false
            }]
        },
        options: {
            indexAxis: 'y',
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    display: false
                },
                tooltip: {
                    backgroundColor: 'rgba(0, 0, 0, 0.8)',
                    padding: 12,
                    cornerRadius: 8,
                    callbacks: {
                        label: function(context) {
                            return 'Doanh thu: ₫' + context.parsed.x.toLocaleString('vi-VN');
                        }
                    }
                }
            },
            scales: {
                x: {
                    beginAtZero: true,
                    ticks: {
                        callback: function(value) {
                            return '₫' + (value / 1000000).toFixed(0) + 'M';
                        }
                    },
                    grid: {
                        color: 'rgba(0, 0, 0, 0.05)'
                    }
                },
                y: {
                    grid: {
                        display: false
                    }
                }
            }
        }
    });
}

function initCustomerGrowthChart(customerGrowth, dailyOrders) {
    const ctx = document.getElementById('customerGrowthChart');
    if (!ctx) return;
    
    console.log('Customer growth data:', customerGrowth);

    const labels = customerGrowth.map(d => {
        const date = new Date(d.Date); // PascalCase from C#
        return `${date.getDate()}/${date.getMonth() + 1}`;
    });
    
    const totalCustomersData = customerGrowth.map(d => d.TotalCustomers); // PascalCase from C#
    const newCustomersData = customerGrowth.map(d => d.NewCustomers); // PascalCase from C#

    customerGrowthChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [
                {
                    label: 'Tổng khách hàng',
                    data: totalCustomersData,
                    borderColor: 'rgb(16, 185, 129)',
                    backgroundColor: 'rgba(16, 185, 129, 0.1)',
                    tension: 0.4,
                    fill: true,
                    pointRadius: 4,
                    pointHoverRadius: 6,
                    pointBackgroundColor: 'rgb(16, 185, 129)',
                    pointBorderColor: '#fff',
                    pointBorderWidth: 2,
                    yAxisID: 'y'
                },
                {
                    label: 'Khách hàng mới/ngày',
                    data: newCustomersData,
                    borderColor: 'rgb(251, 191, 36)',
                    backgroundColor: 'rgba(251, 191, 36, 0.1)',
                    tension: 0.4,
                    fill: false,
                    pointRadius: 4,
                    pointHoverRadius: 6,
                    pointBackgroundColor: 'rgb(251, 191, 36)',
                    pointBorderColor: '#fff',
                    pointBorderWidth: 2,
                    yAxisID: 'y1'
                }
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            interaction: {
                mode: 'index',
                intersect: false
            },
            plugins: {
                legend: {
                    display: true,
                    position: 'top'
                },
                tooltip: {
                    backgroundColor: 'rgba(0, 0, 0, 0.8)',
                    padding: 12,
                    cornerRadius: 8
                }
            },
            scales: {
                y: {
                    type: 'linear',
                    display: true,
                    position: 'left',
                    title: {
                        display: true,
                        text: 'Số khách hàng'
                    },
                    grid: {
                        color: 'rgba(0, 0, 0, 0.05)'
                    }
                },
                y1: {
                    type: 'linear',
                    display: true,
                    position: 'right',
                    title: {
                        display: true,
                        text: 'Khách hàng mới'
                    },
                    grid: {
                        drawOnChartArea: false
                    }
                },
                x: {
                    grid: {
                        display: false
                    }
                }
            }
        }
    });
}
