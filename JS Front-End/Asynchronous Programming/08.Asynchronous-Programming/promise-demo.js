const weddingPromise = new Promise((resolve, reject) => {

    if (Math.random() < 0.5) {
        return reject('Sorry it\'s me!');
    }
    setTimeout(() => {
        resolve('Just Married!');
    }, 3000)
})
weddingPromise
    .then((message) => {
        console.log(message);
    })
    .catch(message => {
        console.log(message);
    })
    .finally(() => {
        console.log('Love always win!!!');
    });