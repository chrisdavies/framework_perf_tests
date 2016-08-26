defmodule Web.PageView do
  use Web.Web, :view

  def active_users do
    Web.RuzUser.active
  end
end
