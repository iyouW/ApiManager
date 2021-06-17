"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
require("reflect-metadata");
const koa_1 = __importDefault(require("koa"));
const cors_1 = __importDefault(require("@koa/cors"));
const koa_bodyparser_1 = __importDefault(require("koa-bodyparser"));
const router_1 = require("./router");
const app = new koa_1.default();
app.use(cors_1.default());
app.use(koa_bodyparser_1.default());
app.use(router_1.router.routes()).use(router_1.router.allowedMethods());
app.listen(3000);
//# sourceMappingURL=server.js.map