import { SwaggerRouter } from 'koa-swagger-decorator'
import { ModuleController } from '../controller/moduleController'

const router = new SwaggerRouter()

// USER ROUTES
router.get("/:projectId/module", ModuleController.getListByProject)
router.put("/module", ModuleController.put)

// Swagger endpoint
router.swagger({
    title: "node-typescript-koa-rest",
    description: "API REST using NodeJS and KOA framework, typescript. TypeORM for SQL with class-validators. Middlewares JWT, CORS, Winston Logger.",
    version: "1.8.0"
})

// mapDir will scan the input dir, and automatically call router.map to all Router Class
router.mapDir(__dirname)

export { router }