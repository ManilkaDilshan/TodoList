# Backend README

This is the README for the backend of the TODO list app. This backend is built using Entity Framework and SQLite as the database.

## Getting Started

1. Clone this repository.

2. Navigate to the `backend` directory.

3. Install the required packages by running:
```bash
dotnet restore
```
4. Run the migrations to create the database schema:
```bash
dotnet ef database update
```
5. Start the backend server:
```bash
dotnet run
```


## API Endpoints

The backend provides the following API endpoints:

#### Get all items

```http
  GET /api/item
```

#### Get item

```http
  GET /api/item/${id}
```

#### Add item

```http
  POST /api/item
```

#### Update item

```http
  PUT /api/item/${id}
```

#### Delete item

```http
  DELETE /api/item/${id}
```

