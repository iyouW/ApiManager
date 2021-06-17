import "reflect-metadata"

import Koa from 'koa'
import cors from '@koa/cors'
import bodyParser from 'koa-bodyparser'

import { projectRouter, proxyRouter, moduleRouter, apiRouter, parameterRouter } from './routers'

const app = new Koa()

app.use(cors())
app.use(bodyParser())

app.use(projectRouter.routes()).use(projectRouter.allowedMethods())
app.use(proxyRouter.routes()).use(projectRouter.allowedMethods())
app.use(moduleRouter.routes()).use(projectRouter.allowedMethods())
app.use(apiRouter.routes()).use(projectRouter.allowedMethods())
app.use(parameterRouter.routes()).use(projectRouter.allowedMethods())

app.listen(3000)
