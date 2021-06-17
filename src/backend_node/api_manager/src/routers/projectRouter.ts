import { SwaggerRouter } from 'koa-swagger-decorator'
import { ProjectController } from '../controller/projectController'

const router = new SwaggerRouter()

// USER ROUTES
router.get("/project", ProjectController.getList)
router.put("/project", ProjectController.put)

// Swagger endpoint
router.swagger({
    title: "node-typescript-koa-rest",
    description: "API REST using NodeJS and KOA framework, typescript. TypeORM for SQL with class-validators. Middlewares JWT, CORS, Winston Logger.",
    version: "1.8.0"
})

// mapDir will scan the input dir, and automatically call router.map to all Router Class
router.mapDir(__dirname)

export { router }