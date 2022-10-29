
//(function ($) {
//    var $window = $(window); $('#preloader').fadeout('normall', function () { $(this).remove(); }); $window.on('scroll', function () { var scroll = $window.scrolltop(); var logoinner = $(".navbar-brand img"); var logowhite = $(".navbar-brand.logowhite img"); if (scroll <= 50) { $("header").removeclass("scrollheader").addclass("fixedheader"); logoinner.attr('src', 'img/logos/logo.png'); logowhite.attr('src', 'img/logos/logo-white.png'); } else { $("header").removeclass("fixedheader").addclass("scrollheader"); logoinner.attr('src', 'img/logos/logo.png'); logowhite.attr('src', 'img/logos/logo.png'); } }); $window.on('scroll', function () { if ($(this).scrolltop() > 500) { $(".scroll-to-top").fadein(400); } else { $(".scroll-to-top").fadeout(400); } }); $(".scroll-to-top").on('click', function (event) { event.preventdefault(); $("html, body").animate({ scrolltop: 0 }, 600); }); var pagesection = $(".parallax,.bg-img"); pagesection.each(function (indx) { if ($(this).attr("data-background")) { $(this).css("background-image", "url(" + $(this).data("background") + ")"); } }); $('.story-video').magnificpopup({ delegate: '.video', type: 'iframe' }); $window.resize(function (event) { settimeout(function () { setresizecontent(); }, 500); event.preventdefault(); }); function fullscreenheight() { var element = $(".full-screen"); var $minheight = $window.height(); element.css('min-height', $minheight); } function screenfixedheight() { var $headerheight = $("header").height(); var element = $(".screen-height"); var $screenheight = $window.height(); element.css('height', $screenheight); } function screenfixedheaderheight() { var $headerheight = $("header").height(); var element = $(".screen-height-header"); var $screenheightheader = $window.height() - $headerheight; element.css('height', $screenheightheader); } function setresizecontent() { fullscreenheight(); screenfixedheight(); screenfixedheaderheight(); } setresizecontent(); $(document).ready(function () {
//        $('#testmonials-carousel').owlcarousel({ loop: true, responsiveclass: true, nav: true, navtext: ["<i class='ti-arrow-left'></i>", "<i class='ti-arrow-right'></i>"], dots: false, autoplay: true, smartspeed: 500, margin: 0, responsive: { 0: { items: 1, nav: false }, 768: { items: 1 }, 992: { items: 1 } } }); $('#testmonials2').owlcarousel({ loop: true, responsiveclass: true, nav: false, navtext: ["<i class='ti-arrow-left'></i>", "<i class='ti-arrow-right'></i>"], dots: false, autoplay: true, smartspeed: 500, margin: 0, responsive: { 0: { items: 1, nav: false }, 768: { items: 1 }, 992: { items: 2, margin: 30 } } }); $('#new-arrivals').owlcarousel({ loop: true, responsiveclass: true, dots: true, nav: false, navtext: ["<i class='fas fa-angle-left'></i>", "<i class='fas fa-angle-right'></i>"], autoplay: true, smartspeed: 500, responsive: { 0: { items: 1, margin: 0 }, 481: { items: 2, margin: 15 }, 768: { items: 2, margin: 20 }, 992: { items: 3, margin: 25 }, 1200: { items: 4, margin: 30 } } }); $('#blog-post').owlcarousel({ loop: true, responsiveclass: true, dots: false, nav: true, autoplay: true, smartspeed: 500, responsive: { 0: { items: 1, nav: false }, 768: { items: 1 }, 992: { items: 1 } } }); $('.carousel-style4 .owl-carousel').owlcarousel({ loop: true, dots: false, nav: true, navtext: ["<i class='fas fa-angle-left'></i>", "<i class='fas fa-angle-right'></i>"], autoplay: true, autoplaytimeout: 5000, responsiveclass: true, autoplayhoverpause: false, responsive: { 0: { items: 1, margin: 0 }, 481: { items: 2, margin: 5 }, 500: { items: 2, margin: 20 }, 992: { items: 3, margin: 30 }, 1200: { items: 4, margin: 30 } } }); $('.slider-fade .owl-carousel').owlcarousel({ items: 1, loop: true, dots: false, margin: 0, nav: true, navtext: ["<i class='fas fa-chevron-left'></i>", "<i class='fas fa-chevron-right'></i>"], autoplay: true, smartspeed: 500, mousedrag: false, animatein: 'fadein', animateout: 'fadeout', responsive: { 0: { nav: false }, 768: { nav: true, } } }); $('.owl-carousel').owlcarousel({ items: 1, loop: true, dots: false, margin: 0, autoplay: true, smartspeed: 500 }); var owl = $('.slider-fade'); owl.on('changed.owl.carousel', function (event) { var item = event.item.index - 2; $('h3').removeclass('animated fadeinright'); $('h1').removeclass('animated fadeinright'); $('p').removeclass('animated fadeinright'); $('.butn').removeclass('animated fadeinright'); $('.owl-item').not('.cloned').eq(item).find('h3').addclass('animated fadeinright'); $('.owl-item').not('.cloned').eq(item).find('h1').addclass('animated fadeinright'); $('.owl-item').not('.cloned').eq(item).find('p').addclass('animated fadeinright'); $('.owl-item').not('.cloned').eq(item).find('.butn').addclass('animated fadeinright'); }); if ($("#rev_slider_1").length !== 0)
//        { var tpj = jquery; var revapi2; tpj(document).ready(function () { if (tpj("#rev_slider_1").revolution == undefined) { revslider_showdoublejqueryerror("#rev_slider_1"); } else { revapi2 = tpj("#rev_slider_1").show().revolution({ slidertype: "standard", sliderlayout: "fullwidth", dottedoverlay: "none", delay: 9000, spinner: "spinner4", navigation: { keyboardnavigation: "off", keyboard_direction: "horizontal", mousescrollnavigation: "off", onhoverstop: "off", touch: { touchenabled: "on", swipe_threshold: 75, swipe_min_touches: 1, swipe_direction: "horizontal", drag_block_vertical: false }, arrows: { enable: true, style: 'metis', tmp: '', rtl: false, hide_onleave: true, hide_onmobile: true, hide_under: 0, hide_over: 9999, hide_delay: 200, hide_delay_mobile: 1200, left: { container: 'slider', h_align: 'left', v_align: 'center', h_offset: 20, v_offset: 0 }, right: { container: 'slider', h_align: 'right', v_align: 'center', h_offset: 20, v_offset: 0 } }, bullets: { enable: false, }, }, responsivelevels: [1240, 1024, 767, 480], gridwidth: [1170, 1170, 767, 480], gridheight: [700, 700, 600, 600], lazytype: "none", shadow: 0, shuffle: "off", autoheight: "off", }); } }); } if ($("#rev_slider_2").length !== 0) { var tpj = jquery; var revapi4; tpj(document).ready(function () { if (tpj("#rev_slider_2").revolution == undefined) { revslider_showdoublejqueryerror("#rev_slider_2"); } else { revapi4 = tpj("#rev_slider_2").show().revolution({ slidertype: "standard", sliderlayout: "fullwidth", dottedoverlay: "none", delay: 9000, spinner: "spinner4", navigation: { keyboardnavigation: "off", keyboard_direction: "horizontal", mousescrollnavigation: "off", onhoverstop: "off", touch: { touchenabled: "on", swipe_threshold: 75, swipe_min_touches: 1, swipe_direction: "horizontal", drag_block_vertical: false }, arrows: { enable: true, style: 'metis', tmp: '', rtl: false, hide_onleave: true, hide_onmobile: true, hide_under: 0, hide_over: 9999, hide_delay: 200, hide_delay_mobile: 1200, left: { container: 'slider', h_align: 'left', v_align: 'center', h_offset: 20, v_offset: 0 }, right: { container: 'slider', h_align: 'right', v_align: 'center', h_offset: 20, v_offset: 0 } }, bullets: { enable: false, }, }, responsivelevels: [1240, 1024, 767, 480], gridwidth: [1280, 1170, 767, 480], gridheight: [700, 700, 600, 600], lazytype: "none", shadow: 0, shuffle: "off", autoheight: "off", }); } }); } if ($(".horizontaltab").length !== 0) { $('.horizontaltab').easyresponsivetabs({ type: 'default', width: 'auto', fit: true, tabidentify: 'hor_1', activate: function (event) { var $tab = $(this); var $info = $('#nested-tabinfo'); var $name = $('span', $info); $name.text($tab.text()); $info.show(); } }); } if ($(".countdown").length !== 0) { var tpj = jquery; var countdown; tpj(document).ready(function () { if (tpj(".countdown").countdown == undefined) { revslider_showdoublejqueryerror(".countdown"); } else { countdown = tpj(".countdown").show().countdown({ date: "01 jan 2021 00:01:00", format: "on" }); } }); } $('.countup').counterup({ delay: 25, time: 2000 });
//    }); $window.on("load", function () { $('.gallery').magnificpopup({ delegate: '.popimg', type: 'image', gallery: { enabled: true } }); var $gallery = $('.gallery').isotope({}); $('.filtering').on('click', 'span', function () { var filtervalue = $(this).attr('data-filter'); $gallery.isotope({ filter: filtervalue }); }); $('.filtering').on('click', 'span', function () { $(this).addclass('active').siblings().removeclass('active'); }); $window.stellar(); });
//})(jquery);





$(document).on("keyup", "#search", function () {
	let inputvalue = $(this).val();
	$("#SearchList li").slice(1).remove();
    $("#SearchList").html()
	console.log(inputvalue)
	$.ajax({
		url: "https://localhost:44374/home/search?search=" + inputvalue,
		method: "get",
        success: function (res) {
            console.log(res)
            $("#SearchList").append(res);
            
            console.log($("#SearchList"))
		}
	})
});


const all = document.getElementById('all')
const accessories = document.getElementById('accessories')
const care = document.getElementById('care')
const clothing = document.getElementById('clothing')
const decor = document.getElementById('decor')
const food = document.getElementById('food')

const all_btn = document.getElementById('all_btn')
const accessories_btn = document.getElementById('accessories_btn')
const care_btn = document.getElementById('care_btn')
const clothing_btn = document.getElementById('clothing_btn')
const decor_btn = document.getElementById('decor_btn')
const food_btn = document.getElementById('food_btn')

let product_active = 1;


//slider

//$('.responsive').slick({
//    dots: true,
//    infinite: false,
//    speed: 300,
//    slidesToShow: 4,
//    slidesToScroll: 4,
//    responsive: [
//        {
//            breakpoint: 1024,
//            settings: {
//                slidesToShow: 3,
//                slidesToScroll: 3,
//                infinite: true,
//                dots: true
//            }
//        },
//        {
//            breakpoint: 600,
//            settings: {
//                slidesToShow: 2,
//                slidesToScroll: 2
//            }
//        },
//        {
//            breakpoint: 480,
//            settings: {
//                slidesToShow: 1,
//                slidesToScroll: 1
//            }
//        }
       
//    ]
//});

//$('.your-class').slick({
//    dots: true,
//    infinite: false,
//    speed: 300,
//    slidesToShow: 1,
//    slidesToScroll: 1,
//    responsive: [
//        {
//            breakpoint: 1024,
//            settings: {
//                slidesToShow: 3,
//                slidesToScroll: 3,
//                infinite: true,
//                dots: true
//            }
//        },
//        {
//            breakpoint: 600,
//            settings: {
//                slidesToShow: 2,
//                slidesToScroll: 2
//            }
//        },
//        {
//            breakpoint: 480,
//            settings: {
//                slidesToShow: 1,
//                slidesToScroll: 1
//            }
//        }
//    ]
//});


new Splide('#thumbnail-carousel', {
    fixedWidth: 1750,
    fixedHeight: 650,
    gap: 10,
    rewind: true,
    pagination: false,
    focus: 'center',
    breakpoints: {
        600: {
            fixedWidth: 60,
            fixedHeight: 44,
        },
    },
}).mount();




//real js


(function ($) {
    //'use strict';





    //add product to basket

 
    //plus item in basket

    //let plusBtn = document.querySelectorAll(".plusitem")
    //plusBtn.forEach(add =>

    //    add.addEventListener("click", function () {

    //        let dataId = this.getAttribute("data-id")
    //        let span = this.previousElementSibling;
    //        let tabletotalprice = this.parentElement.parentElement.parentElement.nextElementSibling;
    //        axios.post("/basket/plus?id=" + dataId)
    //            .then(function (response) {

    //                // handle success
    //                bTotal.innerText = response.data.count
    //                tPrice.innerText = "$" + response.data.price
    //                span.innerText = response.data.main
    //                tabletotalprice.innerText = '$' + response.data.itemTotal
    //                $(`#oneproductCount${dataId}`).html(`${response.data.productcount}`)
    //                //console.log(response.data.main)
    //            })
    //            .catch(function (error) {
    //                console.log(error);
    //            })
    //    })
    //)


    ////minus item in basket


    //let minusBtn = document.querySelectorAll(".minusitem")
    //minusBtn.forEach(add =>
    //    add.addEventListener("click", function () {

    //        let dataId = this.getAttribute("data-id")
    //        let span = this.nextElementSibling
    //        let tr = span.parentElement.parentElement.parentElement.parentElement;
    //        let table = tr.parentElement.parentElement;
    //        let cart_list_item = $(`#cart-item${dataId}`)
    //        let checkoutBtn = table.nextElementSibling;
    //        let tabletotalprice = this.parentElement.parentElement.parentElement.nextElementSibling;
    //        let cntnr = $("#basketcontainer")
    //        let emptywarning = document.createElement("div")
    //        emptywarning.classList.add("container", "d-flex", "flex-row", "justify-content-center")
    //        let emptywarninglink = document.createElement("a")
    //        emptywarninglink.classList.add("text-light", "btn", "btn-danger")
    //        emptywarninglink.setAttribute("href", "home/index")
    //        emptywarninglink.innerText = "Your cart is empty"
    //        emptywarning.append(emptywarninglink)
    //        axios.post("/basket/minus?id=" + dataId)
    //            .then(function (response) {
    //                //console.log(response.data.count)

    //                if (response.data.productcount == 0) {
    //                    //console.log("data zero")
    //                    bTotal.innerText = response.data.main
    //                    tPrice.innerText = response.data.price
    //                    tr.remove();
    //                    cart_list_item.remove()
    //                    if (response.data.main == 0) {
    //                        table.remove();
    //                        checkoutBtn.remove();
    //                        cntnr.append(emptywarning)
    //                        // cntnr.html(`<div class="container d-flex flex-row justify-content-center">< a class="text-light btn btn-danger" asp-controller="home" asp-action="index" > Your cart is empty</a ></div >`);
    //                    }
    //                }
    //                else {
    //                    bTotal.innerText = response.data.main
    //                    tPrice.innerText = "$" + response.data.price
    //                    span.innerText = response.data.count
    //                    tabletotalprice.innerText = response.data.itemTotal;
    //                    //console.log("count " + response.data.count);
    //                    $(`#oneproductCount${dataId}`).html(`${response.data.count} X`)
    //                    //console.log("productcount " + response.data.productcount);
    //                    //console.log(itemcount)

    //                }
    //                //console.log(response);
    //            })
    //            .catch(function (error) {
    //                // handle error

    //                //tr.remove();


    //                console.log(error.message);
    //            })
    //    })
    //)


    ////delete item in basket


    //let delBtn = document.querySelectorAll(".deleteitem")
    //delBtn.forEach(add =>

    //    add.addEventListener("click", function () {

    //        let dataId = this.getAttribute(`data-id`)
    //        let tr = this.parentElement.parentElement.parentElement;
    //        let table = tr.parentElement.parentElement;
    //        let checkoutBtn = table.nextElementSibling;
    //        let cart_list_item = $(`#cart-item${dataId}`)
    //        let cntnr = $("#basketcontainer")
    //        let emptywarning = document.createElement("div")
    //        emptywarning.classList.add("container", "d-flex", "flex-row", "justify-content-center")
    //        let emptywarninglink = document.createElement("a")
    //        emptywarninglink.classList.add("text-light", "btn", "btn-danger")
    //        emptywarninglink.setAttribute("href", "home/index")
    //        emptywarninglink.innerText = "Your cart is empty"
    //        emptywarning.append(emptywarninglink)
    //        //console.log(dataId)
    //        Swal.fire({

    //            title: 'Are you sure?',
    //            text: "You won't be able to revert this!",
    //            icon: 'warning',
    //            showCancelButton: true,
    //            confirmButtonColor: '#d33',
    //            cancelButtonColor: 'rgb(25,135,84)',
    //            confirmButtonText: 'Yes, delete it!'
    //        }).then((result) => {
    //            if (result.isConfirmed) {

    //                axios.post("/basket/RemoveItem?id=" + dataId)
    //                    .then(function (response) {


    //                        bTotal.innerText = response.data.count;
    //                        tPrice.innerText = response.data.price;
    //                        tr.remove();
    //                        cart_list_item.remove()
    //                        if (response.data.count == 0) {
    //                            table.remove();
    //                            checkoutBtn.remove();
    //                            cntnr.append(emptywarning)
    //                            //window.location.reload();

    //                        }
    //                    })
    //                    .catch(function (error) {

    //                        console.log(error);
    //                    })

    //                Swal.fire({
    //                    position: 'center',
    //                    icon: 'success',
    //                    title: 'Product has been deleted from basket',
    //                    showConfirmButton: false,
    //                    timer: 1500
    //                })
    //            }
    //        })

    //    })
    //)


    ////loadMoreComments
    //let skip = 10;
    //$(document).on('click', '#loadmore', function () {
    //    let blogId = this.getAttribute("data-id")

    //    let commentSection = $("#comment-area")
    //    let commentCount = this.getAttribute("com-count")
    //    console.log(commentCount)
    //    $.ajax({
    //        url: "/blog/loadcomments?skip=" + skip + "&BlogId=" + blogId,
    //        method: "get",
    //        success: function (res) {
    //            commentSection.append(res)

    //            let prodelComment = document.querySelectorAll(".pro-deleteComment")
    //            let promainComments = $("#comCount")

    //            prodelComment.forEach(del =>

    //                del.addEventListener("click", function () {
    //                    let dataId = this.getAttribute("data-id")
    //                    axios.post("/blog/DeleteComment?id=" + dataId)
    //                        .then(function (response) {
    //                            console.log(response)
    //                            del.parentElement.parentElement.parentElement.parentElement.remove()
    //                            promainComments.html(response.data.count)
    //                        })
    //                        .catch(function (error) {
    //                            console.log("error " + error);
    //                        })
    //                })
    //            )
    //            skip += 2;

    //            if (skip >= commentCount) {
    //                $(`#loadmore`).remove();
    //            }
    //        },
    //        error: function (err) {
    //            console.log("error ", err)
    //        }
    //    })

    //})



    ////deleteComment
    //let delComment = document.querySelectorAll(".deleteComment")
    //let mainComments = $("#comCount")

    //delComment.forEach(del =>

    //    del.addEventListener("click", function () {
    //        let dataId = this.getAttribute("data-id")
    //        axios.post("/blog/DeleteComment?id=" + dataId)
    //            .then(function (response) {
    //                console.log(response)
    //                del.parentElement.parentElement.parentElement.parentElement.remove()
    //                mainComments.html(response.data.count)
    //            })
    //            .catch(function (error) {
    //                console.log("error " + error);
    //            })
    //    })
    //)




    ////delete from basket cart

    ///*let deleteBtn = document.querySelectorAll(".deletefromcart")
    //deleteBtn.forEach(add =>

    //    add.addEventListener("click", function () {

    //        let dataId = this.getAttribute(`data-id`)
    //        let basketcart = this.parentElement;
            
    //        console.log(dataId)
    //        axios.post("/basket/RemoveItem?id=" + dataId)
    //            .then(function (response) {


    //                bTotal.innerText = response.data.count;
    //                tPrice.innerText = response.data.price;
    //                basketcart.remove();
    //            })
    //            .catch(function (error) {
    //                console.log(error);
    //            })
    //    })
    //)*/

    ////add product to wishlist
    //let wishlistAddBtn = document.querySelectorAll(".add-to-wishlist")
    //wishlistAddBtn.forEach(add =>

    //    add.addEventListener("click", function () {
    //        let dataId = this.getAttribute("data-id")

    //        axios.post("/wishlist/add?id=" + dataId)
    //            .then(function (response) {
    //                if (response.data.online) {
    //                    add.remove();
    //                }
    //                else {
    //                    Swal.fire({
    //                        title: 'You need to login to add to wishlist',
    //                        showDenyButton: false,
    //                        showCancelButton: true,
    //                        confirmButtonText: 'Login',
    //                        denyButtonText: `Don't save`,
    //                    }).then((result) => {
    //                        /* Read more about isConfirmed, isDenied below */
    //                        if (result.isConfirmed) {
    //                            location.replace("account/login")
    //                        }
    //                    })
    //                }
    //                //console.log(response);
    //            })
    //            .catch(function (error) {
    //                // handle error
    //                console.log("error " + error);
    //            })
    //    })
    //)



    ////remove from wishlist
    //let wishlistRmvBtn = document.querySelectorAll(".remove-from-wishlist")
    //wishlistRmvBtn.forEach(add =>

    //    add.addEventListener("click", function () {
    //        let wishlistItemCard = this.parentElement.parentElement.parentElement.parentElement;
    //        let dataId = this.getAttribute("data-id")
    //        axios.post("/wishlist/remove?id=" + dataId)
    //            .then(function (response) {
    //                // handle success
    //                wishlistItemCard.remove();
    //                //console.log(response);
    //            })
    //            .catch(function (error) {
    //                // handle error
    //                console.log("error " + error);
    //            })
    //    })
    //)



    ////add product to wishlist from cards
    //let cardHeartAddBtn = document.querySelectorAll(".add-to-wishlist-from-card")
    //cardHeartAddBtn.forEach(add =>

    //    add.addEventListener("click", function () {
    //        let dataId = this.getAttribute("data-id");
    //        let icon = document.createElement("i");
    //        let parent = this.parentElement;
    //        axios.post("/wishlist/add?id=" + dataId)
    //            .then(function (response) {
    //                add.innerHTML = "";

    //                icon.classList.add("fa-heart");
    //                icon.classList.add("fa-solid");
    //                icon.classList.add("text-danger");
    //                //console.log(icon)
    //                add.append(icon);
    //                Swal.fire({
    //                    position: 'bottom-end',
    //                    icon: 'success',
    //                    title: 'Succesfully added to your wishlist',
    //                    showConfirmButton: false,
    //                    timer: 1000
    //                })

    //                setTimeout(
    //                    function () {
    //                        parent.remove();
    //                    }, 1000);

    //            })
    //            .catch(function (error) {
    //                // handle error
    //                console.log("error " + error);
    //            })
    //    }
    //    )
    //)



    ////cart-modal
    //let modalBtn = document.querySelectorAll(".modal-open-btn")
    //modalBtn.forEach(add =>

    //    add.addEventListener("click", function () {
    //        let modalImage = $("#modal-image")
    //        let dataId = this.getAttribute(`data-id`)
    //        let modalAdd = $("#modal-add-btn")
    //        let productName = $("#modal-product-name")
    //        let productPrice = $("#modal-product-price")
    //        let productDesc = $("#modal-product-desc")

    //        // console.log(dataId, modalAdd, productName, productPrice, productDesc)
    //        //console.log(dataId)
    //        axios.post("/search/GetProductForModal?id=" + dataId)
    //            .then(function (response) {
    //                modalAdd.attr(`href`, `home/detail/${dataId}`);
    //                productName.text(response.data.name)
    //                productPrice.text(`$` + response.data.price)
    //                productDesc.text(response.data.description)
    //                modalImage.attr(`src`, `images/products/${response.data.image}`)
    //                modalImage.attr(`width`, `100%`)

    //            })
    //            .catch(function (error) {
    //                console.log(error);
    //            })
    //    })
    //)




    ////subscribe
    //const regexExp = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/gi;

    //let par = document.getElementById("getsubbed")

    //$("#getsubbed").click(function () {
    //    let email = $("#mail").val()
    //    if (regexExp.test(email)) {
    //        axios.post("/Subscription/Subscribe?email=" + email)
    //            .then(function (response) {
    //                Swal.fire({
    //                    position: 'center',
    //                    icon: 'success',
    //                    title: email + ' subscribed. Thanks for subscribing',
    //                    showConfirmButton: false,
    //                    timer: 2000
    //                })
    //                console.log(response)
    //                par.parentElement.parentElement.parentElement.parentElement.remove()
    //            })
    //            .catch(function (error) {
    //                Swal.fire({
    //                    icon: 'error',
    //                    title: 'Oops... Email exists or another error',
    //                    text: error.error,
    //                })
    //            })
    //    }
    //    else {
    //        Swal.fire({
    //            icon: 'error',
    //            title: 'Oops...',
    //            text: 'Try spelling correct email form',
    //        })
    //    }

    //});



    ////addcomment



    //let postBtn = $("#post-comment")

    //postBtn.click(function () {
    //    let num = document.getElementById("comCount")
    //    let commentnumber = $("#comCount").text()
    //    console.log(num.innerText)
    //    let comment = $("#comment-input").val()
    //    let blogId = this.getAttribute("data-id")
    //    let author = $("#comment-name").val()
    //    let cmntarea = $("#comment-area")



    //    if (comment.length > 3) {
    //        if (author != undefined || author != null) {
    //            if (author.length > 3) {
    //                axios.post("/blog/PostComment?id=" + blogId + "&comment=" + comment + "&author=" + author)
    //                    .then(function (response) {
    //                        $("#comment-area").prepend(response.data)
    //                        let numb = document.getElementById("comment-area").childElementCount;

    //                        $("#comCount").text(numb)
    //                        $("#comment-input").val("")
    //                        $("#comment-name").val("")
    //                        $("#comment-warning").text("")


    //                        let prodelComment = document.querySelectorAll(".pro-deleteComment")
    //                        let promainComments = $("#pro-comCount")

    //                        prodelComment.forEach(del =>

    //                            del.addEventListener("click", function () {
    //                                let dataId = this.getAttribute("data-id")
    //                                axios.post("/blog/DeleteComment?id=" + dataId)
    //                                    .then(function (response) {
    //                                        console.log(response)
    //                                        del.parentElement.parentElement.parentElement.parentElement.remove()
    //                                        promainComments.html(response.data.count)
    //                                    })
    //                                    .catch(function (error) {
    //                                        console.log("error " + error);
    //                                    })
    //                            })
    //                        )
    //                    })
    //                    .catch(function (error) {
    //                        console.log(error)
    //                    })
    //            }
    //            else {
    //                $("#name-warning").text("Name must be 3 or longer than")
    //            }
    //        }
    //        else {
    //            axios.post("/blog/PostComment?id=" + blogId + "&comment=" + comment)
    //                .then(function (response) {
    //                    $("#comment-area").prepend(response.data)
    //                    let numb = document.getElementById("comment-area").childElementCount;



    //                    $("#comCount").text(numb)
    //                    console.log(response)
    //                    $("#comment-input").val("")
    //                    $("#comment-warning").text("")
    //                    let prodelComment = document.querySelectorAll(".pro-deleteComment")
    //                    let promainComments = $("#comCount")

    //                    prodelComment.forEach(del =>

    //                        del.addEventListener("click", function () {
    //                            let dataId = this.getAttribute("data-id")
    //                            axios.post("/blog/DeleteComment?id=" + dataId)
    //                                .then(function (response) {
    //                                    console.log(response)
    //                                    del.parentElement.parentElement.parentElement.parentElement.remove()
    //                                    promainComments.html(response.data.count)
    //                                })
    //                                .catch(function (error) {
    //                                    console.log("error " + error);
    //                                })
    //                        })
    //                    )
    //                })
    //                .catch(function (error) {
    //                    console.log(error)
    //                })
    //        }
    //    }
    //    else {
    //        $("#comment-warning").text("Length must be longer than 3")
    //    }

    //});



    ////product page

    ////addProductComment

    //let propostBtn = $("#pro-post-comment")

    //propostBtn.click(function () {
    //    let pronum = document.getElementById("pro-comCount")
    //    let procommentnumber = $("#pro-comCount").text()

    //    let procomment = $("#pro-comment-input").val()
    //    let problogId = this.getAttribute("data-id")
    //    let proauthor = $("#pro-comment-name").val()
    //    let procmntarea = $("#pro-comment-area")


    //    if (procomment.length > 3) {
    //        if (proauthor != undefined || proauthor != null) {
    //            if (proauthor.length > 3) {
    //                axios.post("/home/PostComment?ProductId=" + problogId + "&comment=" + procomment + "&author=" + proauthor)
    //                    .then(function (response) {
    //                        $("#pro-comment-area").prepend(response.data)
    //                        let numb = document.getElementById("pro-comment-area").childElementCount;
    //                        console.log("lol: " + numb)
    //                        $("#pro-comCount").text(numb)
    //                        console.log(response)
    //                        $("#pro-comment-input").val("")
    //                        $("#pro-comment-name").val("")
    //                        $("#pro-comment-warning").text("")

    //                        let prodelComment = document.querySelectorAll(".pro-deleteComment")
    //                        let promainComments = $("#pro-comCount")

    //                        prodelComment.forEach(del =>

    //                            del.addEventListener("click", function () {
    //                                let dataId = this.getAttribute("data-id")
    //                                axios.post("/home/DeleteComment?id=" + dataId)
    //                                    .then(function (response) {
    //                                        console.log(response)
    //                                        del.parentElement.parentElement.parentElement.parentElement.remove()
    //                                        promainComments.html(response.data.count)

    //                                    })
    //                                    .catch(function (error) {
    //                                        console.log("error " + error);
    //                                    })
    //                            })
    //                        )
    //                    })
    //                    .catch(function (error) {
    //                        console.log(error)
    //                    })
    //            }
    //            else {
    //                $("#pro-name-warning").text("Name must be 3 or longer than")
    //            }
    //        }
    //        else {
    //            axios.post("/home/PostComment?ProductId=" + problogId + "&comment=" + procomment)
    //                .then(function (response) {
    //                    $("#pro-comment-area").prepend(response.data)
    //                    let numb = document.getElementById("pro-comment-area").childElementCount;
    //                    console.log("lol: " + numb)


    //                    $("#pro-comCount").text(numb)
    //                    console.log(response)
    //                    $("#pro-comment-input").val("")
    //                    $("#pro-comment-warning").text("")

    //                    let prodelComment = document.querySelectorAll(".pro-deleteComment")
    //                    let promainComments = $("#pro-comCount")

    //                    prodelComment.forEach(del =>

    //                        del.addEventListener("click", function () {
    //                            let dataId = this.getAttribute("data-id")
    //                            axios.post("/home/DeleteComment?id=" + dataId)
    //                                .then(function (response) {
    //                                    console.log(response)
    //                                    del.parentElement.parentElement.parentElement.parentElement.remove()
    //                                    promainComments.html(response.data.count)
    //                                })
    //                                .catch(function (error) {
    //                                    console.log("error " + error);
    //                                })
    //                        })
    //                    )
    //                })
    //                .catch(function (error) {
    //                    console.log(error)
    //                })
    //        }
    //    }
    //    else {
    //        $("#pro-comment-warning").text("Length must be longer than 3")
    //    }

    //});

    ////loadMoreComments
    //let proSkip = 10;
    //$(document).on('click', '#pro-loadmore', function () {
    //    let blogId = this.getAttribute("data-id")

    //    let commentSection = $("#pro-comment-area")
    //    let commentCount = this.getAttribute("com-count")
    //    console.log(commentCount)
    //    $.ajax({
    //        url: "/home/loadcomments?skip=" + proSkip + "&BlogId=" + blogId,
    //        method: "get",
    //        success: function (res) {
    //            commentSection.append(res)
    //            proSkip += 2;
    //            let prodelComment = document.querySelectorAll(".pro-deleteComment")
    //            let promainComments = $("#pro-comCount")

    //            prodelComment.forEach(del =>

    //                del.addEventListener("click", function () {
    //                    let dataId = this.getAttribute("data-id")
    //                    axios.post("/home/DeleteComment?id=" + dataId)
    //                        .then(function (response) {
    //                            console.log(response)
    //                            del.parentElement.parentElement.parentElement.parentElement.remove()
    //                            promainComments.html(response.data.count)
    //                        })
    //                        .catch(function (error) {
    //                            console.log("error " + error);
    //                        })
    //                })
    //            )
    //            if (proSkip >= commentCount) {
    //                $(`#pro-loadmore`).remove();
    //            }
    //        },
    //        error: function (err) {
    //            console.log("error ", err)
    //        }
    //    })

    //})



    ////deleteComment
    //let prodelComment = document.querySelectorAll(".pro-deleteComment")
    //let promainComments = $("#pro-comCount")

    //prodelComment.forEach(del =>

    //    del.addEventListener("click", function () {
    //        let dataId = this.getAttribute("data-id")
    //        axios.post("/home/DeleteComment?id=" + dataId)
    //            .then(function (response) {
    //                console.log(response)
    //                del.parentElement.parentElement.parentElement.parentElement.remove()
    //                promainComments.html(response.data.count)
    //            })
    //            .catch(function (error) {
    //                console.log("error " + error);
    //            })
    //    })
    //)




    ////rate product
    //let rate = $("#rate-btn")

    //rate.click(function () {
    //    let rating = this.getAttribute("rating")
    //    let productId = this.getAttribute("data-id")
    //    if (rating != null || rating != undefined) {
    //        axios.post("/Home/Rate?Rating=" + rating + "&ProductId=" + productId)
    //            .then(function (response) {
    //                console.log(response.data)
    //                if (response.data.result) {
    //                    Swal.fire({
    //                        timer: 2000,
    //                        timerProgressBar: true,
    //                        title: 'Thanks for rating!',
    //                        text: `${response.data.name}`,
    //                        imageUrl: `/images/products/${response.data.image}`,
    //                        imageWidth: 400,
    //                        imageHeight: 200,
    //                        imageAlt: 'Custom image',
    //                    })
    //                    //$("#rate-btn").remove();
    //                    setTimeout(
    //                        function () {
    //                            window.location.reload()
    //                        }, 3000);
    //                }
    //            })
    //            .catch(function (error) {
    //                console.log(error)
    //            })
    //    }
//    })
})