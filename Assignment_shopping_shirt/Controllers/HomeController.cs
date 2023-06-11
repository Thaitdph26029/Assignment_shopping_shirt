using Assignment_shopping_shirt.IService;
using Assignment_shopping_shirt.Models;
using Assignment_shopping_shirt.Service;
using Assignment_shopping_shirt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Composition.Convention;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace Assignment_shopping_shirt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;
        private readonly ISupplierService _supplierService;
        private readonly IRoleService _roleService;
        private readonly IProductServices _productService;
        private readonly IProductDetailsService _productDetailsService;
        private readonly IUserService _userService;
        private readonly IBillService _billService;
        private readonly IBillDetailService _billDetailService;
        private readonly ICartService _cartService;
        private readonly ICartDetailService _cartDetailService;
        ShopDbContext context = new ShopDbContext();




        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _colorService = new ColorService();
            _sizeService = new SizeService();
            _supplierService = new SupplierService();
            _roleService = new RoleService();
            _userService = new UserService();
            _productService = new ProductServices();
            _billService = new BillService();
            _billDetailService = new BillDetailService();
            _cartService = new CartService();
            _cartDetailService = new CartDetailService();
            _productDetailsService = new ProductDetailsService();
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Color
        public IActionResult Color()
        {
            List<Color> colors = _colorService.GetAllColors();
            return View(colors);
        }

        public IActionResult CreateColor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateColor(Color c)
        {
            if (_colorService.CreatColor(c))
            {
                return RedirectToAction("Color");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult EditColor(Guid id)
        {
            Color c = _colorService.GetColorById(id);
            return View(c);
        }
        public IActionResult EditColor(Color c)
        {
            if (_colorService.UpdateColor(c))
            {
                return RedirectToAction("Color");
            }
            else
                return BadRequest();
        }
        public IActionResult DetailColor(Guid id)
        {
            ShopDbContext context = new ShopDbContext();
            var c = context.Colors.Find(id);
            return View(c);
        }
        public IActionResult DeleteColor(Guid id)
        {
            if (_colorService.DeleteColor(id))
            {
                return RedirectToAction("Color");
            }
            else
                return BadRequest();
        }

        //Size

        public IActionResult Size()
        {
            List<Size> sizes = _sizeService.GetAllSizes();
            return View(sizes);
        }

        public IActionResult CreateSize()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSize(Size s)
        {
            if (_sizeService.CreatSize(s))
            {
                return RedirectToAction("Size");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult EditSize(Guid id)
        {
            Size s = _sizeService.GetSizeById(id);
            return View(s);
        }
        public IActionResult EditSize(Size s)
        {
            if (_sizeService.UpdateSize(s))
            {
                return RedirectToAction("Size");
            }
            else
                return BadRequest();
        }
        public IActionResult DetailSize(Guid id)
        {
            ShopDbContext context = new ShopDbContext();
            var s = context.Sizes.Find(id);
            return View(s);
        }
        public IActionResult DeleteSize(Guid id)
        {
            if (_sizeService.DeleteSize(id))
            {
                return RedirectToAction("Size");
            }
            else
                return BadRequest();
        }
        //Supplier
        public IActionResult Supplier()
        {
            List<Supplier> Supplier = _supplierService.GetAllSuppliers();
            return View(Supplier);
        }

        public IActionResult CreateSupplier()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSupplier(Supplier s)
        {
            if (_supplierService.CreatSupplier(s))
            {
                return RedirectToAction("Supplier");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult EditSupplier(Guid id)
        {
            Supplier s = _supplierService.GetSupplierById(id);
            return View(s);
        }
        public IActionResult EditSupplier(Supplier s)
        {
            if (_supplierService.UpdateSupplier(s))
            {
                return RedirectToAction("Supplier");
            }
            else
                return BadRequest();
        }
        public IActionResult DetailSupplier(Guid id)
        {
            ShopDbContext context = new ShopDbContext();
            var s = context.Suppliers.Find(id);
            return View(s);
        }
        public IActionResult DeleteSupplier(Guid id)
        {
            if (_supplierService.DeleteSupplier(id))
            {
                return RedirectToAction("Supplier");
            }
            else
                return BadRequest();
        }

        //Role
        public IActionResult Role()
        {
            List<Role> Role = _roleService.GetAllRoles();
            return View(Role);
        }

        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateRole(Role r)
        {
            if (_roleService.CreatRole(r))
            {
                return RedirectToAction("Role");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult EditRole(Guid id)
        {
            Role r = _roleService.GetRoleById(id);
            return View(r);
        }
        public IActionResult EditRole(Role s)
        {


            var json = JsonConvert.SerializeObject(_roleService.GetRoleById(s.Id));
            HttpContext.Session.SetString("lab5", JsonConvert.SerializeObject(json));
            if (_roleService.UpdateRole(s))
            {
                return RedirectToAction("showrolelab5");
            }
            else
                return BadRequest();
        }
        public IActionResult showrolelab5()
        {
            string jsondata = HttpContext.Session.GetString("lab5");
            if (jsondata == null)
            {
                return View();
            }
            var products = JsonConvert.DeserializeObject<List<Role>>(jsondata);

            return View(products);
        }

        public IActionResult DetailRole(Guid id)
        {
            ShopDbContext context = new ShopDbContext();
            var s = context.Roles.Find(id);
            return View(s);
        }
        public IActionResult DeleteRole(Guid id)
        {
            if (_roleService.DeleteRole(id))
            {
                return RedirectToAction("Role");
            }
            else
                return BadRequest();
        }

        //Product

        public IActionResult Product()
        {
            List<Product> Product = _productService.GetAllProducts();
            return View(Product);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product r, [Bind] IFormFile imageFile)
        {
            var x = imageFile.FileName;
            if (imageFile != null && imageFile.Length > 0) //không null và không trống
            {
                //Trỏ tới thư mục wwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    //thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }
                //Gán lại giá trị cho desciption của đối tượng bằng tên file ảnh đã được sao chép
                r.Image = imageFile.FileName;
            }
            r.Id = Guid.NewGuid();
            if (_productService.CreatProduct(r))
            {
                return RedirectToAction("Product");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult ShowListProductDetails(Guid id)
        {
            ProductDetails productdetails = _productDetailsService.GetProductDetailsById(id);
            //var _lstProductdetail = _productDetailsService.GetAllProductDetailss().Where(x => x.ProductId == id).ToList();
            ViewBag.A = TempData["Alert"];
            var product = _productService.GetAllProducts().Where(x => x.Id == id).FirstOrDefault();
            HttpContext.Session.SetString("checkproduct", JsonConvert.SerializeObject(product));
            using (ShopDbContext context = new ShopDbContext())
            {
                var _lstProductdetail = context.ProductDetails.Where(x => x.ProductId == id).Include("Suppliers").Include("Colors").Include("Products").Include("Sizes").ToList();
                return View(_lstProductdetail);
            }
            //return View(_lstProductdetail);
        }
        public IActionResult RemoveProductDetails(Guid id)
        {
            var productDetails = _productDetailsService.GetAllProductDetailss().Where(x => x.Id == id).FirstOrDefault();
            HttpContext.Session.SetString("productDetails", JsonConvert.SerializeObject(productDetails));
            if (_productDetailsService.DeleteProductDetails(id))
            {
                var productsdetails = HttpContext.Session.GetString("checkproduct");
                Product a = JsonConvert.DeserializeObject<Product>(productsdetails);
                TempData["Alert"] = "Delete Success";
                //  return ShowListProductDetails(a.Id);
                return RedirectToAction("ShowListProductDetails", "Home", new { id = a.Id });
                // return View();
            }
            else
                return BadRequest();
        }
        public IActionResult RollBackProductDetais()
        {
            var productsdetails = HttpContext.Session.GetString("productDetails");
            if (productsdetails == null)
            {
                return View();
            }
            ProductDetails ProductDetails = JsonConvert.DeserializeObject<ProductDetails>(productsdetails);
            ;
            if (_productDetailsService.CreatProductDetails(ProductDetails))
            {
                var productsdetails1 = HttpContext.Session.GetString("checkproduct");
                Product a = JsonConvert.DeserializeObject<Product>(productsdetails1);
                ViewBag.A = "1";
                //  return ShowListProductDetails(a.Id);
                return RedirectToAction("ShowListProductDetails", "Home", new { id = a.Id });
                // return View();
            }
            else
                return BadRequest();

        }
        public IActionResult CreatProductDetails()
        {
            var color = context.Colors.ToList();
            ViewBag.color = new SelectList(color, "ID", "Name");
            var supplier = context.Suppliers.ToList();
            ViewBag.suppliers = new SelectList(supplier, "ID", "Name");
            var size = context.Sizes.ToList();
            ViewBag.size = new SelectList(size, "ID", "Name");
            var product = HttpContext.Session.GetString("checkproduct");
            Product products = JsonConvert.DeserializeObject<Product>(product);
            ViewBag.productid = products.Id;
            return View();
        }
        [HttpPost]
        public IActionResult CreatProductDetails(ProductDetails p)
        {

            if (_productDetailsService.CreatProductDetails(p))
            {
                return RedirectToAction("CreatProductDetails");
            }
            else return BadRequest();
        }

        public IActionResult DeleteProduct(Guid id)
        {

            if (_productDetailsService.DeleteProductDetails(id))
            {
                return Content("Xóa thành công");

            }
            else
                return BadRequest();
        }





        public IActionResult RemoveProduct(Guid id)
        {
            if (_productService.DeleteProduct(id))
            {
                return RedirectToAction("Product");
            }
            else
                return BadRequest();
        }
        [HttpGet]
        public IActionResult UpdateProducts(Guid id)
        {
            Product r = _productService.GetProductById(id);
            return View(r);
           
        }
        public IActionResult UpdateProducts(Product p, [Bind] IFormFile imageFile)
        {
            var x = imageFile.FileName;
            if (imageFile != null && imageFile.Length > 0) //không null và không trống
            {
                //Trỏ tới thư mục wwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    //thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }
                //Gán lại giá trị cho desciption của đối tượng bằng tên file ảnh đã được sao chép
                p.Image = imageFile.FileName;
            }
            if (_productService.UpdateProduct(p))
            {
                return RedirectToAction("Product");
            }
            else
                return BadRequest();
        }
        //public IActionResult EditProduct(Product s)
        //{
        //    if (_productService.UpdateProduct(s))
        //    {

        //        return RedirectToAction("Product");


        //    }
        //    else if (_productService.UpdateProduct(s) == false)
        //    {
        //        return Content("EditProduct");
        //    }
        //    else

        //        return BadRequest();

        //}

        //public IActionResult DetailProduct(Guid id)
        //{
        //    ShopDbContext context = new ShopDbContext();
        //    var s = context.Products.Find(id);
        //    return View(s);
        //}
        //public IActionResult DeleteProduct(Guid id)
        //{
        //    if (_productService.DeleteProduct(id))
        //    {
        //        return RedirectToAction("Product");
        //    }
        //    else
        //        return BadRequest();
        //}

        //User
        public IActionResult User()
        {
            List<User> User = _userService.GetAllUsers();
            return View(User);
        }

        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(User r)
        {
            if (_userService.CreatUser(r))
            {
                return RedirectToAction("User");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult EditUser(Guid id)
        {
            User r = _userService.GetUserById(id);
            return View(r);
        }
        public IActionResult EditUser(User s)
        {
            if (_userService.UpdateUser(s))
            {
                return RedirectToAction("User");
            }
            else
                return BadRequest();
        }
        public IActionResult DetailUser(Guid id)
        {
            ShopDbContext context = new ShopDbContext();
            var s = context.Users.Find(id);
            return View(s);
        }
        public IActionResult DeleteUser(Guid id)
        {
            if (_userService.DeleteUser(id))
            {
                return RedirectToAction("User");
            }
            else
                return BadRequest();
        }

        //Bill

        public IActionResult Bill()
        {
            List<Bill> Bill = _billService.GetAllBills();
            return View(Bill);
        }

        public IActionResult CreateBill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBill(Bill r)
        {
            if (_billService.CreatBill(r))
            {
                return RedirectToAction("Bill");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult EditBill(Guid id)
        {
            Bill r = _billService.GetBillById(id);
            return View(r);
        }
        public IActionResult EditBill(Bill s)
        {
            if (_billService.UpdateBill(s))
            {
                return RedirectToAction("Bill");
            }
            else
                return BadRequest();
        }
        public IActionResult DetailBill(Guid id)
        {
            ShopDbContext context = new ShopDbContext();
            var s = context.Bills.Find(id);
            return View(s);
        }
        public IActionResult DeleteBill(Guid id)
        {
            if (_billService.DeleteBill(id))
            {
                return RedirectToAction("Bill");
            }
            else
                return BadRequest();
        }


        //BillDetail
        public IActionResult BillDetail()
        {
            List<BillDetail> BillDetail = _billDetailService.GetAllBillDetails();
            return View(BillDetail);
        }

        public IActionResult CreateBillDetail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBillDetail(BillDetail r)
        {
            if (_billDetailService.CreatBillDetail(r))
            {
                return RedirectToAction("BillDetail");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult EditBillDetail(Guid id)
        {
            BillDetail r = _billDetailService.GetBillDetailById(id);
            return View(r);
        }
        public IActionResult EditBillDetail(BillDetail s)
        {
            if (_billDetailService.UpdateBillDetail(s))
            {
                return RedirectToAction("BillDetail");
            }
            else
                return BadRequest();
        }
        public IActionResult DetailBillDetail(Guid id)
        {
            ShopDbContext context = new ShopDbContext();
            var s = context.BillDetails.Find(id);
            return View(s);
        }
        public IActionResult DeleteBillDetail(Guid id)
        {
            if (_billDetailService.DeleteBillDetail(id))
            {
                return RedirectToAction("BillDetail");
            }
            else
                return BadRequest();
        }

        //Cart
        public IActionResult Cart()
        {
            List<Cart> Cart = _cartService.GetAllCarts();
            return View(Cart);
        }

        public IActionResult CreateCart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCart(Cart r)
        {
            if (_cartService.CreatCart(r))
            {
                return RedirectToAction("Cart");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult EditCart(Guid id)
        {
            Cart r = _cartService.GetCartById(id);
            return View(r);
        }
        public IActionResult EditCart(Cart s)
        {
            if (_cartService.UpdateCart(s))
            {
                return RedirectToAction("Cart");
            }
            else
                return BadRequest();
        }
        public IActionResult DetailCart(Guid id)
        {
            ShopDbContext context = new ShopDbContext();
            var s = context.Carts.Find(id);
            return View(s);
        }
        public IActionResult DeleteCart(Guid id)
        {
            if (_cartService.DeleteCart(id))
            {
                return RedirectToAction("Cart");
            }
            else
                return BadRequest();
        }

        //CartDetail
        public IActionResult CartDetail()
        {
            List<CartDetail> CartDetail = _cartDetailService.GetAllCartDetails();
            return View(CartDetail);
        }

        public IActionResult CreateCartDetail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCartDetail(CartDetail r)
        {
            if (_cartDetailService.CreatCartDetail(r))
            {
                return RedirectToAction("CartDetail");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult EditCartDetail(Guid id)
        {
            CartDetail r = _cartDetailService.GetCartDetailById(id);
            return View(r);
        }
        public IActionResult EditCartDetail(CartDetail s)
        {
            if (_cartDetailService.UpdateCartDetail(s))
            {
                return RedirectToAction("CartDetail");
            }
            else
                return BadRequest();
        }
        public IActionResult DetailCartDetail(Guid id)
        {
            ShopDbContext context = new ShopDbContext();
            var s = context.CartDetails.Find(id);
            return View(s);
        }
        public IActionResult DeleteCartDetail(Guid id)
        {
            if (_cartDetailService.DeleteCartDetail(id))
            {
                return RedirectToAction("CartDetail");
            }
            else
                return BadRequest();
        }


        //Shop
        public IActionResult Shop()
        {

            using (ShopDbContext context = new ShopDbContext())
            {
                var list = context.Products.Where(x => x.Status < 3).ToList();
                return View(list);
            }

        }
         
        public IActionResult DetailShop(Guid id) // id của product
        {
            ShopDbContext context = new ShopDbContext();
            var productDetails = _productDetailsService.GetAllProductDetailss().Where(x => x.ProductId == id).ToList();
            List<Color> color = new List<Color>();
            List<Size> size = new List<Size>();
            //for (int i = 0; i < productDetails.Count(); i++)
            //{
            //    /*= context.Colors.Where(x => x.ID == productDetails[i].ColorID).ToList();*/
            //    color.Add(context.Colors.Where(x => x.ID == productDetails[i].ColorID).FirstOrDefault());

            //    size.Add(context.Sizes.Where(x => x.ID == productDetails[i].SizeID).FirstOrDefault());
            //}
            for (int i = 0; i < productDetails.Count(); i++)
            {
                /*= context.Colors.Where(x => x.ID == productDetails[i].ColorID).ToList();*/
                if (i == 0)
                {
                    color.Add(context.Colors.Where(x => x.ID == productDetails[i].ColorID).FirstOrDefault());
                    size.Add(context.Sizes.Where(x => x.ID == productDetails[i].SizeID).FirstOrDefault());
                }

                for (int j = 0; j < color.Count(); j++)
                {

                    if (color[j].ID != productDetails[i].ColorID)
                    {
                        color.Add(context.Colors.Where(x => x.ID == productDetails[i].ColorID).FirstOrDefault());
                        break;
                    }
                    else
                    {
                        break;
                    }

                }
                for (int j = 0; j < color.Count(); j++)
                {

                    if (size[j].ID != productDetails[i].SizeID)
                    {
                        size.Add(context.Sizes.Where(x => x.ID == productDetails[i].SizeID).FirstOrDefault());
                        break;
                    }
                    else
                    {
                        break;
                    }

                }


            }

            ViewBag.color = color;
            ViewBag.size = size;

            //for (int i = 0; i < productDetails.Count; i++)
            //{
            //    color = context.Colors.Where(x => x.ID == productDetails[i].ColorID).ToList();
            //}

            //ViewBag.color = new SelectList(color, "ID", "Name");
            //var supplier = context.Suppliers.ToList();
            //ViewBag.suppliers = new SelectList(supplier, "ID", "Name");
            //var size = context.Sizes.ToList();
            //ViewBag.size = new SelectList(size, "ID", "Name");
            var s = context.Products.Include("ProductDetails").FirstOrDefault(x => x.Id == id);
            return View(s);
        }
        //public IActionResult AddToCart()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult AddToCart(Guid product, Guid ColorID, Guid SizeID, int quantity)
        {
            string user = HttpContext.Session.GetString("login");
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            User users = JsonConvert.DeserializeObject<User>(user);




            List<Cart> Carts = _cartService.GetAllCarts().Where(x => x.UserId == users.Id).ToList();
            //Lấy ra productdetail đấy 
            ProductDetails productDetails = _productDetailsService.GetAllProductDetailss().Where(x => x.ProductId == product && x.SizeID == SizeID && x.ColorID == ColorID).FirstOrDefault();
            //Check xem giỏ hàng đã có productdetail đấy hay chưa 
            if (productDetails==null)
            {
                return Content("Sản phẩm này hết rồi");
            }
            List<CartDetail> cartDetails = _cartDetailService.GetAllCartDetails().Where(x => x.UserId == users.Id && x.ProductID == productDetails.Id).ToList();
            if (cartDetails.Count == 0)
            {
                //Cart cart = new Cart()
                //{
                //    UserId = users.Id,
                //    Description = "!",
                //};
                //_cartService.CreatCart(cart);
                CartDetail cartDetail = new CartDetail()
                {
                    Id = Guid.NewGuid(),
                    UserId = users.Id,
                    ProductID = productDetails.Id,
                    Quantity = quantity,
                };
                _cartDetailService.CreatCartDetail(cartDetail);
                return RedirectToAction("ShowCart");

            }
            else
            {

                CartDetail cartDetail = new CartDetail();
                cartDetail = _cartDetailService.GetAllCartDetails().Where(x => x.UserId == users.Id && x.ProductID == productDetails.Id).FirstOrDefault();
                cartDetail.Quantity = cartDetail.Quantity + quantity;
                _cartDetailService.UpdateCartDetail(cartDetail);
                return RedirectToAction("ShowCart");
            }

        }
        public IActionResult ShowCart()
        {
            string user = HttpContext.Session.GetString("login");
            if (user == null)
            {
                ViewData["CheckLogin"] = "1";
                return RedirectToAction("Login");

            }
            User users = JsonConvert.DeserializeObject<User>(user);
            //  List<CartDetail> cartDetails = _cartDetailService.GetAllCartDetails().Where(x => x.UserId == users.Id).ToList();

            //using (ShopDbContext context = new ShopDbContext())
            //{
            //    var list = context.CartDetails.Where(x => x.UserId == users.Id).Include("ProductDetails").ToList();
            //    return View(list);
            //}
            //  return View(list);

            List<CartDetail> cartDetails = context.CartDetails.Include("ProductDetails").Where(x => x.UserId == users.Id).ToList();
            List<ProductDetails> productDetails = context.ProductDetails.Include("Sizes").Include("Colors").Include("Products").ToList();

            ViewBag.CartDetail = cartDetails;
            ViewBag.ProductDetails = productDetails;
            return View();
        }
        //public IActionResult RemoveCartDetails(Guid ID)
        //{
        //    if (_cartDetailService.DeleteCartDetail(id))
        //    {
        //        return ShowCart();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        [HttpPost]
        public IActionResult Pay()
        {
            string user = HttpContext.Session.GetString("login");
            if (user == null)
            {
                ViewBag.Message = "Vui long dang nhap";
                return RedirectToAction("Login");

            }
            User users = JsonConvert.DeserializeObject<User>(user);

            var list = _cartDetailService.GetAllCartDetails().Where(x => x.UserId == users.Id);
            //Nếu giỏ hàng chưa có đồ thì bắt mua
            if (list.Count() == 0)
            {
                return RedirectToAction("ProductIndex");
            }
            else
            {
                Guid id = Guid.NewGuid();
                //Nếu giỏ hàng có đồ thì tạo hóa đơn, hóa đơn chi tiết và xóa dữ liệu trong giỏ hàng 
                Bill bill = new Bill()
                {
                    Id = id,
                    CreateDate = DateTime.Now,
                    UserID = users.Id,
                    Status = 1,
                };
                _billService.CreatBill(bill);
                var listCartDetail = _cartDetailService.GetAllCartDetails().Where(x => x.UserId == users.Id).ToList(); //danh sách giỏ hàng
                for (int i = 0; i < listCartDetail.Count(); i++)
                {
                    var ProductDetails = _productDetailsService.GetProductDetailsById(listCartDetail[i].ProductID);//lấy ra 1 sản phẩm;
                    var Product = _productService.GetAllProducts().Where(x => x.Id == ProductDetails.ProductId).FirstOrDefault();//lấy ra 1 sản phẩm để lấy giá;
                    var cartdetail = _cartDetailService.GetAllCartDetails().FirstOrDefault(x => x.ProductID == ProductDetails.Id && x.UserId == users.Id);//lấy ra thằng giỏ hàng chi tiết để lấy số lượng
                    BillDetail billDetail = new BillDetail();
                    billDetail.ID = Guid.NewGuid();
                    billDetail.BillID = id;
                    billDetail.ProductID = ProductDetails.Id;
                    billDetail.Quantity = cartdetail.Quantity;
                    billDetail.Price = cartdetail.Quantity * Product.Price;
                    _billDetailService.CreatBillDetail(billDetail);
                    //Add 1 sản phẩm vào bill detail
                    //Sau đó Update số lượng
                    ProductDetails.AvailableQuantity = ProductDetails.AvailableQuantity - cartdetail.Quantity;
                    _productDetailsService.UpdateProductDetails(ProductDetails);
                    //Xóa ở CartDetail
                    _cartDetailService.DeleteCartDetail(cartdetail.Id);
                }
                return RedirectToAction("ProductIndex");
            }
        }
        [HttpGet]
        public IActionResult UpdateProductDetails(Guid id)
        {
            var color = context.Colors.ToList();
            ViewBag.color = new SelectList(color, "ID", "Name");
            var supplier = context.Suppliers.ToList();
            ViewBag.suppliers = new SelectList(supplier, "ID", "Name");
            var size = context.Sizes.ToList();
            ViewBag.size = new SelectList(size, "ID", "Name");
            ProductDetails p = _productDetailsService.GetProductDetailsById(id);
            return View(p);
        }
        public IActionResult UpdateProductDetails(ProductDetails p)
        {
           
            if (_productDetailsService.UpdateProductDetails(p))
            {
                var productsdetails1 = HttpContext.Session.GetString("checkproduct");
                Product a = JsonConvert.DeserializeObject<Product>(productsdetails1);
                ViewBag.A = "1";
                //  return ShowListProductDetails(a.Id);
                return RedirectToAction("ShowListProductDetails", "Home", new { id = a.Id });
                // return View();
                //return View();
            }
            else
                return BadRequest();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("login");
            return RedirectToAction("login");
        }

        public IActionResult Bills()
        {
            string user = HttpContext.Session.GetString("login");
            if (user == null)
            {
                return RedirectToAction("Login");

            }
            User users = JsonConvert.DeserializeObject<User>(user);

          //  List<Bill> bills = _billService.GetAllBills().Where(x => x.UserID == users.Id).ToList();
            using (ShopDbContext context = new ShopDbContext())
            {
                var bills = context.Bills.Where(x => x.UserID == users.Id).Include("User").Include("BillDetails").ToList();               
                return View(bills);
            }
            //return View(bills);
        }

        public IActionResult ShowBillDetail(Guid id)
        {
            List<BillDetail> billDetails = context.BillDetails.Include("ProductDetails").Where(x => x.BillID == id).ToList();
            List<ProductDetails> productDetails = context.ProductDetails.Include("Sizes").Include("Colors").Include("Products").ToList();
            ViewBag.billdetails = billDetails;
            ViewBag.ProductDetails = productDetails;
            return View();
        }
        //Shop
        public IActionResult ProductIndex()
        {

            using (ShopDbContext context = new ShopDbContext())
            {
                var list = context.Products.ToList();
                return View(list);
            }

        }


        //Login 

        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(string users, string pass)
        {
            var regex = new Regex(@"^[A-Za-z0-9]{7,}$");
            if (regex.IsMatch(users))
            {
                var user = _userService.GetAllUsers().Where(x => x.Username.Trim() == users && x.Password.Trim() == pass).FirstOrDefault();
                if (user != null)
                {

                    HttpContext.Session.SetString("login", JsonConvert.SerializeObject(user));
                    return RedirectToAction("ProductIndex");
                }
                else
                {
                    ViewBag.LabelText = "Tài khoản hoặc mật khẩu sai";
                    return View();
                }
            }
            else
            {
                ViewBag.LabelText1 = "Phải lớn hơn 6 ký tự,không được chứa ký tự đặc biệt";
                return View();
            }

        }
        [HttpGet]
        public IActionResult Search()
        {
            List<Product> products = _productService.GetAllProducts();
            return View(products);
        }
        public IActionResult Search(int min,int max)
        {
            if (min<max)
            {
                List<Product> products = _productService.GetAllProducts().Where(x=>x.Price<=max & x.Price>=min).ToList();
                return View(products);
            }           
            else
            {
                List<Product> products = _productService.GetAllProducts();
                return View(products);
               // return View();
            }
            

        }




        public IActionResult Manage()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}