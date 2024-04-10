function placeOrder(drink) {
    return new Promise(function(resolve, reject) {
        if (drink == 'coffee') {
            resolve('Order for Coffee received');
        }
        else {
            reject('Order rejected');
        }
    })
};

function processOrder(order) {
    return new Promise(function(resolve) {
        console.log('Order is being processing');
        resolve(`${order} is Served`);
    })
};

async function serve() {
    await placeOrder('coffee').then(function(orderplaced){
        console.log(orderplaced);
        let orderProceesed = processOrder(orderplaced);
        return orderProceesed;
    }).then(function(orderProceesed){
        console.log(orderProceesed);
    }).catch(err=>{
        console.log(err);
    })
}


async function serveOrder() {
    try {
        let orderplaced = await placeOrder('coffee');
        console.log(orderplaced);
        let processorder = await processOrder(orderplaced);
        console.log(processorder);
    }
    catch (err){
        console.log(err);
    }
}

async function startprocess() {
    await serve();
    console.log("============================");
    await serveOrder();
}

startprocess();