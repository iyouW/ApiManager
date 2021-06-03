<template>
  <div id="app" class="layout">
    <Header></Header>
    <Content>
      <Row type="flex" justify="center">
        <Col span="18">
          <div class="app-container">
            <router-view />
          </div>
        </Col>
      </Row>
    </Content>
  </div>
</template>
<style lang="less" scoped>
.app-container{
  padding-top:30px;
}
</style>