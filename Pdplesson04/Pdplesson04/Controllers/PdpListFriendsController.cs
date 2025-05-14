using Microsoft.AspNetCore.Mvc;
using PdpLesson4.Models;
using System.Collections.Generic;

namespace PdpLesson4.Controllers
{
    public class PdpListFriendsController : Controller
    {
        // Static list to store friends in memory
        private static List<PdpListFriends> friends = new List<PdpListFriends>
        {
            new PdpListFriends
            {
                ID = 1,
                Age = 21,
                Name = "Phạm Đình Phùng",
                Address = "Nghệ An",
                Image = "/images/bunbohue.jpg",
                FavoriteFood = "Bún Bò Huế"
            },
            new PdpListFriends
            {
                ID = 2,
                Age = 23,
                Name = "Trần Ngọc Bích",
                Address = "Cần Thơ",
                Image = "/images/comtam.jpg",
                FavoriteFood = "Cơm Tấm"
            },
            new PdpListFriends
            {
                ID = 3,
                Age = 20,
                Name = "Lê Quốc Hùng",
                Address = "Huế",
                Image = "/images/banhxeo.jpg",
                FavoriteFood = "Bánh Xèo"
            },
            new PdpListFriends
            {
                ID = 4,
                Age = 22,
                Name = "Võ Nhật Hạ",
                Address = "Khánh Hòa",
                Image = "/images/nemnuong.jpg",
                FavoriteFood = "Nem Nướng"
            },
            new PdpListFriends
            {
                ID = 5,
                Age = 24,
                Name = "Đinh Văn Huy",
                Address = "Bình Dương",
                Image = "/images/bundau.jpg",
                FavoriteFood = "Bún Đậu Mắm Tôm"
            },
            new PdpListFriends
            {
                ID = 6,
                Age = 25,
                Name = "Nguyễn Thanh Trúc",
                Address = "Lâm Đồng",
                Image = "/images/banhcanh.jpg",
                FavoriteFood = "Bánh Canh Cá Lóc"
            }
        };

        public IActionResult PdpListFriends()
        {
            ViewBag.Friends = friends;
            return View();
        }

        [HttpGet]
        public IActionResult PdpCreateFriends()
        {
            PdpListFriends pdpListFriends = new PdpListFriends();
            return View(pdpListFriends);
        }

        [HttpPost]
        public IActionResult PdpCreateSubmitFriends(PdpListFriends friend)
        {
            // Tự động tăng ID
            friend.ID = friends.Count > 0 ? friends[^1].ID + 1 : 1;
            friends.Add(friend);
            return RedirectToAction("PdpListFriends");
        }

        [HttpGet]
        public IActionResult PdpEditFriends(int id)
        {
            var friend = friends.Find(f => f.ID == id);
            if (friend == null)
                return NotFound();
            return View(friend);
        }

        [HttpPost]
        public IActionResult PdpEditSubmitFriends(PdpListFriends updatedFriend)
        {
            var friend = friends.Find(f => f.ID == updatedFriend.ID);
            if (friend != null)
            {
                friend.Name = updatedFriend.Name;
                friend.Age = updatedFriend.Age;
                friend.Address = updatedFriend.Address;
                friend.Image = updatedFriend.Image;
                friend.FavoriteFood = updatedFriend.FavoriteFood;
            }
            return RedirectToAction("PdpListFriends");
        }

        [HttpGet]
        public IActionResult PdpDeleteFriends(int id)
        {
            var friend = friends.Find(f => f.ID == id);
            if (friend == null)
                return NotFound();
            return View(friend);
        }

        [HttpPost, ActionName("PdpDeleteFriends")]
        public IActionResult PdpDeleteFriendsConfirmed(int id)
        {
            var friend = friends.Find(f => f.ID == id);
            if (friend != null)
            {
                friends.Remove(friend);
            }
            return RedirectToAction("PdpListFriends");
        }
    }
}

