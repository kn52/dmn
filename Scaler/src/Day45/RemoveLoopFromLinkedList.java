package Day45;

public class RemoveLoopFromLinkedList {

	public static void main(String[] args) {
		int[] array = new int[] { 3, 2, 4, 5, 6 };
		ListNode head = new ListNode(array[0]);
		var temp = head;
		ListNode temp2 = null;
		for (int i = 1; i < array.length; i++) {
			ListNode new_node = new ListNode(array[i]);
			temp.next = new_node;
			if (i == 1) {
				head.next = temp;
			}
			if (new_node.val == 4) {
				temp2 = new_node;
			}
			temp = temp.next;
		}
		temp.next = temp2;
		ListNode ans = solve(head);
		printElement(ans);
	}
	public static ListNode solve(ListNode A) {
        ListNode slow=A, fast=A;
        if(A == null){
            return null;
        }
        boolean cycle=false;
        while(fast.next != null && fast.next.next!= null){
            slow=slow.next;
            fast=fast.next.next;
            if(slow == fast){
                cycle =true;
                break;
            }
        }
        if(cycle == false){
            return null;
        }
        ListNode p1=A, p2=slow;
        while(p1 != p2){
            p1=p1.next;
            p2=p2.next;
        }
        ListNode end=p1;
        while(end.next != p1){
            end=end.next;
        }
        end.next=null;
        return A;
    }
	public static void printElement(ListNode head) {
		ListNode temp = head;
		while (temp != null) {
			System.out.print(temp.val);
			temp = temp.next;
		}
	}
}
