"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.router = void 0;
const koa_swagger_decorator_1 = require("koa-swagger-decorator");
const projectController_1 = require("./controller/projectController");
const router = new koa_swagger_decorator_1.SwaggerRouter();
exports.router = router;
// USER ROUTES
router.get("/project", projectController_1.ProjectController.getList);
router.put("/project", projectController_1.ProjectController.put);
// Swagger endpoint
router.swagger({
    title: "node-typescript-koa-rest",
    description: "API REST using NodeJS and KOA framework, typescript. TypeORM for SQL with class-validators. Middlewares JWT, CORS, Winston Logger.",
    version: "1.8.0"
});
// mapDir will scan the input dir, and automatically call router.map to all Router Class
router.mapDir(__dirname);
//# sourceMappingURL=router.js.map