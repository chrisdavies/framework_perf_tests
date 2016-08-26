class RuzUser < ActiveRecord::Base
  self.table_name = "users"

  # Get all active users
  def self.active
    RuzUser.where(state: 'active')
      .select([:name, :email, :crypted_password, :salt, :time_zone, :state, :created_at, :updated_at, :id])
      .order(email: :desc)
  end
end
