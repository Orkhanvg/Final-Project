let plusItem = document.querySelectorAll(".item-plus"); (+ buttonlatinin class adi budur )


plusItem.forEach(m => {



    m.addEventListener("click", function () {

        let dataId = this.getAttribute('data-id');
        let parentBig = this.parentElement.parentElement.parentElement;
        let dataCount = this.parentElement.children[1];


        axios.post(`/basket/itemplus?id=${dataId}`)
            .then(function (response) {

                HeaderBasketCount.innerText = response.data.basketCount;
                HeaderSubTotal.innerText = response.data.subTotal;

                dataCount.innerText = response.data.count;

            })
            .catch(function (error) {
                // handle error
                console.log(error);
            });

    })
})