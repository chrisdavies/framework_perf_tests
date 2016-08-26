class UsersController < ApplicationController
  def index
    @active_users = RuzUser.active
  end
end