$(document).ready(function () {

    let addBtn = document.querySelectorAll(".product-cart2")
    

    
    addBtn.forEach(add =>
        add.addEventListener("click", function () {
        
            let dataId = this.getAttribute("data-id")
            //let quantity = $("#product-quantity").val()
    

            axios.post("/basket/additem?id=" + dataId)
                .then(function (response) {
                  
                   
                    $(".rounded-circle").html(response.data.count)
                    $(".CART").html(response.data.price)
                    $(`#oneproductCount${response.data.id}`).html(`${response.data.productcount} X`)

                    console.log(response.data);
                })
                .catch(function (error) {

                    console.log("error " + error);
                })

        })
    )




    
        


    //wishlist

    let wishlistBtns = [...document.querySelectorAll(".fa-heart")].map(wishtlistIcon => wishtlistIcon.parentElement)


    wishlistBtns.forEach(btn => {
        btn.addEventListener('click', (e) => {
            e.preventDefault();

            let productId = e.target.parentElement.getAttribute('data-id');


            e.target.classList.remove('far');
            e.target.classList.add('fas');

            let wishlistUrl = `/wishlist/additem/${productId}`;

            axios.post(wishlistUrl)
                .then(function (response) {
                    if (response.data.online) {
                        add.remove();
                    }
                    else {
                        Swal.fire({
                            title: 'You need to login to add to wishlist',
                            showDenyButton: false,
                            showCancelButton: true,
                            confirmButtonText: 'Login',
                            denyButtonText: `Don't save`,
                        }).then((result) => {
                            /* Read more about isConfirmed, isDenied below */
                            if (result.isConfirmed) {
                                location.replace("account/login")
                            }
                        })
                    }
                    //console.log(response);
                })
                .catch(function (error) {
                    // handle error
                    console.log("error " + error);
                })
        })
    })


    //plus item
   
    let plusBtns = document.querySelectorAll(".plusitem")
    plusBtns.forEach(plusBtn =>

        plusBtn.addEventListener("click", function() {

            let dataId = this.getAttribute("data-id");
            let quantitySpan = this.previousElementSibling;
            let productSubTotal = this.closest('tr').querySelector('.total-amount');


            axios.get("/basket/plusitem/"+ dataId) 
                .then(function (response) {
                    if (response.data.length > 5) {
                        return;
                    }
                    quantitySpan.innerText = `${response.data.productCount}`;
                    productSubTotal.innerText = `$${response.data.productCount * response.data.price}`;
                    updateCartTotal(response.data);
                })
                .catch(function (error) {
                    console.log(error);
                })
        })

    )

    function updateCartTotal(data) {
        let cartSubTotal = document.querySelector("#product-total-price");
        let cartTotal = document.querySelector("#totalSumPlusMax");

        cartSubTotal.innerText = `$${data.totalPrice}`;
        cartTotal.innerText = `${data.totalPrice + 3}`;
    }

    let minusBtns = document.querySelectorAll(".minusitem")
    minusBtns.forEach(minusBtn =>
        minusBtn.addEventListener("click", function () {
            let dataId = this.getAttribute("data-id");
            let quantitySpan = this.nextElementSibling;
            let productSubTotal = this.closest('tr').querySelector('.total-amount');

            axios.get("/basket/minusitem/" + dataId)
                .then(function (response) {
                    if (response.data.length > 5) {
                        return;
                    }
                    quantitySpan.innerText = `${response.data.productCount}`;
                    productSubTotal.innerText = `$${response.data.productCount * response.data.price}`;
                    updateCartTotal(response.data);
                })
                .catch(function (error) {
                    console.log(error);
                })
        })

    )


    //remove item

    basketRemoveBtns = document.querySelectorAll(".product-delete > a");

    basketRemoveBtns.forEach(basketRemoveBtn =>
        basketRemoveBtn.addEventListener("click", function (ev) {
            ev.preventDefault();

            let removeUrl = ev.target.parentElement.href;

            console.log(removeUrl)

            axios.get(removeUrl)
                .then(function (response) {
                    ev.target.closest('tr').remove();
                })
                .catch(function (error) {
                    console.log(error);
                })
        })
    )

});





//gallery


$(document).ready(function () {
    $("img").click(function () {
        var t = $(this).attr("src");
        $(".modal-body").html("<img src='" + t + "' class='modal-img'>");
        $("#myModal").modal();
    });

   
});//EOF Document.ready