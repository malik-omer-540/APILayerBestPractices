# 📚 APILayerBestPractices

A simple, real-world **.NET 8 RESTful Web API** built **without Entity Framework** using **in-memory collections**. This project demonstrates proper RESTful architecture, HTTP method usage, and clean API design using a **Reader–Book borrowing system**.

---

## 🚀 Features

- 📖 Book management (CRUD)
- 👤 Reader registration & lookups
- 🔁 Borrow and return books
- 🛠 Designed with API layer best practices in mind
- ✅ RESTful routing & versioning (`/api/v1`)
- 🔄 Clean service/controller separation (no EF Core)
- 🧪 Swagger UI for API testing

---

## 📌 API Layer Best Practices Demonstrated

This project is a hands-on reference for building maintainable APIs with proper structure. Here's what we did right:

### ✅ 1. **Separation of Concerns**
- Controllers only handle HTTP request/response.
- Business logic is offloaded to **dedicated services** (`BookService`, `ReaderService`).

### ✅ 2. **Proper Use of HTTP Methods**
| HTTP Verb | Used For                       |
|-----------|--------------------------------|
| `GET`     | Fetching books/readers         |
| `POST`    | Creating books or readers      |
| `PUT`     | Full update of a book          |
| `PATCH`   | Returning a book (partial op)  |
| `DELETE`  | Deleting a book                |

No misuse like `POST /getBooks`—each method reflects its intended purpose.

### ✅ 3. **Consistent and Clean Routing**
- Uses RESTful resource naming (`/api/v1/books`, not `/api/bookList`)
- Uses **plural nouns** for resource collections
- Reflects **hierarchy** via nested endpoints:
  - `/readers/{readerId}/borrow?bookId=1`

### ✅ 4. **Versioning**
- API versioned under `/api/v1` so future changes won’t break old clients.

### ✅ 5. **Proper HTTP Status Codes**
- `200 OK`, `201 Created`, `204 No Content`, `404 Not Found`, `400 Bad Request` used correctly.

### ✅ 6. **Minimal but Sufficient Response Body**
- `CreatedAtAction(...)` used to return `Location` headers for new resources.
- `NoContent()` returned where appropriate to reduce payload size.

### ✅ 7. **Swagger Documentation Out of the Box**
- Automatically generated via `AddSwaggerGen()` to make your API explorable by others.

---

## 📂 Project Structure

```plaintext
BookVerse.API
│
├── Controllers
│   ├── BooksController.cs
│   └── ReadersController.cs
│
├── Models
│   ├── Book.cs
│   └── Reader.cs
│
├── Services
│   ├── BookService.cs
│   └── ReaderService.cs
│
├── Program.cs
